using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //ICategoryDal dan türetmemizin sebebi içinde IGenericDal var , IGenericDal da da ekleme,silme güncelleme gibi işlemler var onların içerisine erişim sağlayabilmek için böyle bir yöntem kullandık:

        private readonly ICategoryDal _categoryDal;


        //yukarıda oluşturduğumuz field dan bir constructor oluşturduk, constructor bizim yerimize new leme işlemini gerçekleştiriyor,yani nesne örneğini alıyor(bu da dependency injection olarak geçiyor):
        public CategoryManager(ICategoryDal categoryDal) 
        {
            _categoryDal = categoryDal;
        }
        public void TDelete(int id)
        {
           _categoryDal.Delete(id);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TInsert(Category entity)
        {
            if (entity.CategoryName.Length>=5 && entity.CategoryName.Length<= 50)
            {
                _categoryDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

    }
}
