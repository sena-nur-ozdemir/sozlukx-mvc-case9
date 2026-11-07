using EntityLayer.Concrete;
using System.Collections.Generic;
namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal : IGenericRepository<Heading>
    {
        List<Heading> ListWithRelations();
    }
}