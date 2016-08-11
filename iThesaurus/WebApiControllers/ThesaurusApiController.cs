using iThesaurus.Domain.Abstract;
using iThesaurus.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace iThesaurus.WebApiControllers
{
    public class ThesaurusApiController : ApiController
    {
        private readonly IThesaurus _thesaurus;

        public ThesaurusApiController(IThesaurus thesaurus)
        {
            _thesaurus = thesaurus;
        }

        // GET: api/ThesaurusApi
        public IEnumerable<string> Get()
        {
            return _thesaurus.GetWords();
        }

        // GET: api/ThesaurusApi/{word}
        public IEnumerable<string> Get(string word)
        {
            try {
                return _thesaurus.GetSynonyms(word);
            }
            catch (KeyNotFoundException)
            {
                return Enumerable.Empty<string>();
            }
        }

        // POST: api/ThesaurusApi
        public bool Post(WordWithSynonyms data)
        {
            bool retval = true;

            try
            {
                _thesaurus.AddSynonyms(data.Word, data.Synonyms);
            }
            catch (Exception)
            {
                // TODO: Log
                retval = false;
            }

            return retval;
        }
    }
}
