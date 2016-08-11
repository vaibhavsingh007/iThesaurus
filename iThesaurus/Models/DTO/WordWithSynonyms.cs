using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iThesaurus.Models.DTO
{
    public class WordWithSynonyms
    {
        public string Word { get; set; }
        public IEnumerable<string> Synonyms { get; set; }
    }
}