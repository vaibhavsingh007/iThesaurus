using iThesaurus.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace iThesaurus.Data.Repositories.Abstract
{
    public interface IWordRepository : IBaseRepository<ThesaurusWord>
    {
        IEnumerable<ThesaurusWord> Words { get; }
    }
}
