using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //Business katmanında abstract klasöründe yer alan interfaceler Service olarak adlandırılıyor.
    //Business katmanında concreate Klasörü içerisinde yer alan sınıflar manager olarak adlandrılıyor.
    public class CategoryManeger : ICategoryService
    {
        EFCategoryRepository efCategoryRepository;
        public CategoryManeger()
        {
            efCategoryRepository = new EFCategoryRepository();
        }

        public void CategoryAdd(Category category)
        {
            efCategoryRepository.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }

        public List<Category> GetList()
        {
            return efCategoryRepository.GetListAll();
        }
    }
}
