using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //dışarıdan bir T değeri alıyor ve bu T değeri bir class olmalı, kullanacağımız class adını T yazan yere yazıyoruz
    {
        void Insert(T entity);
        void Delete(int Id);
        void Update(T entity);
        List<T> GetAll(); //hepsini getirmek istediğimizde List kullanıyoruz
        T GetById(int id); //id ye göre getirmesini istiyoruz
    }
}
