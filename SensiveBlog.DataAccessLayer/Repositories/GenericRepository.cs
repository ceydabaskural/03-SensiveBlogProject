using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.Repositories
{
    //burada GenericRepository classına bir interfaci(IGenericDal<T>) miras alıyoruz bu yüzden interface in içinde bulunan metotların miras verildiği sınıf içinde bulunması gerek. Çünkü sınıflar interfacalerden miras aldığı zaman o interfacelerin içinde yer alan metotların ilgili sınıfta mutlaka tanımlanması gerek(impelement interface dediğimizde bunu kolayla yapıyor)
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SensiveContext _context;
        public GenericRepository(SensiveContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            //entitylerden tamamen bağımsız crud işlemlerinde tekrarı önleyen bir yapı kullandık ve bunun ismi Repository Tasarım Deseni : crud işlemlerinde tekrarı önler
            var value=_context.Set<T>().Find(id); //T: entitylere refer ediyor
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)  //void olmayanlar return eder
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity) //void olanlar return etmez
        {
             _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
