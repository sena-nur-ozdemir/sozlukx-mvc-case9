using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        public List<Heading> ListWithRelations()
        {
            using (var db = new DictionaryContext())
            {
                return db.Headings.AsNoTracking()
                  .Include(x => x.Category).Include(x => x.Writer)
                  .ToList();
            }
        }
    }
}