using iThesaurus.Data.Entities;
using iThesaurus.Data.Repositories.Abstract;
using iThesaurus.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iThesaurus.Domain.Concrete
{
    public class Thesaurus : IThesaurus
    {
        private IWordRepository _wordsRepo;

        #region ctor
        public Thesaurus(IWordRepository wordsRepo)
        {
            _wordsRepo = wordsRepo;
        }

        #endregion

        #region Public
        public void AddSynonyms(string word, IEnumerable<string> synonyms)
        {
            try
            {
                var thesaurusWord = _wordsRepo.Find(word);

                if (thesaurusWord == null)
                {
                    thesaurusWord = AddNewWord(word);
                }

                // Analyze delta
                var newSynonyms = synonyms.Except(thesaurusWord.Synonyms.Select(s => s.Word));

                foreach (var newSynonym in newSynonyms)
                {
                    // Check if synonym already exists as a word.
                    // Must avoid redundancy. 
                    var synonym = _wordsRepo.Find(newSynonym);

                    if (synonym == null)
                    {
                        synonym = new ThesaurusWord
                        {
                            Word = newSynonym
                        };
                    }

                    thesaurusWord.Synonyms.Add(synonym);
                }

                _wordsRepo.Update(thesaurusWord);
            }
            catch (Exception e)
            {
                // TODO : Log
                throw;
            }
        }

        /// <summary>
        /// Direct Synonyms: Selects this word's synonyms and the words for which this word is in turn a synonym.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public IEnumerable<string> GetSynonyms(string word)
        {
            try
            {
                var thesaurusWord = _wordsRepo.Find(word);

                if (thesaurusWord == null)
                {
                    throw new KeyNotFoundException("The specified word does not exist in the thesaurus.");
                }

                return thesaurusWord.Synonyms.Select(s => s.Word)
                    .Union(_wordsRepo.Words.Where(w => w.Synonyms.Contains(thesaurusWord)).Select(s => s.Word));
            }
            catch (Exception e)
            {
                // TODO: Log
                throw;
            }
        }

        public IEnumerable<string> GetWords()
        {
            return _wordsRepo.Words.Select(w => w.Word);
        }

        #endregion

        #region Private

        private ThesaurusWord AddNewWord(string word)
        {
            return _wordsRepo.Insert(new ThesaurusWord { Word = word });
        }

        #endregion
    }
}
