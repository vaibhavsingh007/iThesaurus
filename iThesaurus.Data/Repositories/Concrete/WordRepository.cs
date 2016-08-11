using iThesaurus.Data.Entities;
using iThesaurus.Data.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace iThesaurus.Data.Repositories.Concrete
{
    public class WordRepository : BaseRepository<ThesaurusWord>, IWordRepository
    {
        public WordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<ThesaurusWord> Words
        {
            get
            {
                return GetDbSet().AsEnumerable();
            }
        }
    }
}
