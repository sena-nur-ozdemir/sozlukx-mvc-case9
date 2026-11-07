using EntityLayer.Concrete;
using System.Collections.Generic;
namespace DataAccessLayer.Abstract
{
    public interface IContentDal : IGenericRepository<Content>
    {
        List<Content> ListWithRelations();
    }
}