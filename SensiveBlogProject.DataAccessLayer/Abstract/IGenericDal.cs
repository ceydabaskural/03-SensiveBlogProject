using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.DataAccessLayer.Abstract
{
    //bu yapıyı tüm entitylerimizde kullanacağız. T değeri bizim entitylerimize refer ediyor ve 'class' derken de T değerinin bir sınıf olduğunu belirtmiş oluyoruz
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity); //komple güncelleme olduğu için T türünde entity alır, id değil.
        List<T> GetAll();
        T GetById(int id);
    }
}
