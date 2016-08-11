using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iThesaurus.Data.Entities
{
    /// <summary>
    /// Code First POCO
    /// </summary>
    public class ThesaurusWord
    {
        public ThesaurusWord()
        {
            Synonyms = new List<ThesaurusWord>();
        }
        //public int Id { get; set; }   <-- Would like to use an int PK instead.

        [Key]
        public string Word { get; set; }

        /// <summary>
        /// A lazy-loaded navigation property aka foreign key.
        /// </summary>
        public virtual List<ThesaurusWord> Synonyms { get; set; }
    }
}
