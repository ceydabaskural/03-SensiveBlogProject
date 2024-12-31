using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using SensiveBlog.DataAccessLayer.Repositories;
using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.EntityFramework
{
    //ICategoryDal dan miras almasının sebebi sadece kategoriye ait metodumuz olabilir
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        //consctructor oluşturmamızın sebebi GenericRepositoryde constructor oluşturduk ve içinde'SensiveContext context' isimli parametre var burada EfCategoryDal da Generic Repositoryden miras aldığı için ve generic rep içinde de parametre olduğu için burada da parametre bekliyor o yüzden paramatreyi bize constructor içinde veriyor 
        public EfCategoryDal(SensiveContext context) : base(context)
        {
        }

    }
}
