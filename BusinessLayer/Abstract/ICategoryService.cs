using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        List<Category> GetActiveList();

        Category GetByID(int id);

        void CategoryAdd(Category category);
        void CategoryUpdate(Category category);

        void CategoryDelete(int id);
        void CategoryActivate(int id);
    }
}
