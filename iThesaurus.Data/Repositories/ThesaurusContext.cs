using iThesaurus.Data.Entities;
using iThesaurus.Data.Repositories.Abstract;
using System.Data.Entity;

namespace iThesaurus.Data.Repositories
{
    public class ThesaurusContext : DbContext, IUnitOfWork
    {
        public DbSet<ThesaurusWord> Words { get; set; }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
