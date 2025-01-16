using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.BusinessLayer.Abstract
{
    //aynı işlemi data acces in içinde yaptık business katmanında bir daha aynısını yapmanın amacı
    //dal da yaptığımız crud işlemlerini ve listeleme işlemlerini yapacak, businessdakiler ise bizim presentation üzerinden mantıksal sorgulamamalarının yapılıp bu sorgulamalardan doğru bir şekilde geçtikten sonra işlem yapmamızı sağlayan metotlar olacak

    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TDelete(int id);
        void TUpdate(T entity); 
        List<T> TGetAll();
        T TGetById(int id);
    }
}
