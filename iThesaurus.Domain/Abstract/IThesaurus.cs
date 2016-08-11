using System.Collections.Generic;

namespace iThesaurus.Domain.Abstract
{
    public interface IThesaurus
    {
        /// <summary>
        /// Adds the given synonyms to the thesaurus.
        /// </summary>
        /// <param name="synonyms"></param>
        void AddSynonyms(string word, IEnumerable<string> synonyms);

        /// <summary>
        /// Gets the synonyms for the word.
        /// </summary>
        /// <param name="word">Synonyms for this word are returned.</param>
        IEnumerable<string> GetSynonyms(string word);

        /// <summary>
        /// Gets all the words in the thesaurus.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetWords();
    }
}
