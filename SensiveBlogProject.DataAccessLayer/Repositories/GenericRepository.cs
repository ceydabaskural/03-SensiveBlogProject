using SensiveBlogProject.DataAccessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class //sınıflar interface den miras aldıklarında mutlaka ilgili sınıfta tanımlanması gerekiyor.
    {
        private readonly SensiveContext _context;
        public GenericRepository(SensiveContext context)
        {
            _context = context;
        }

        //Repository Design Pattern : crud işlemlerinden tekrarı önleyen bir tasarım desenidir
        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);                                   
        }
    }
}
