using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
        public List<Content> ListWithRelations()
        {
            using (var db = new DictionaryContext())
            {
                return db.Contents.AsNoTracking()
                  .Include(x => x.Heading).Include(x => x.Writer)
                  .ToList();
            }
        }
    }
}