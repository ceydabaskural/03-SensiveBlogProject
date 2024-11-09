using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.Context;
using SensiveBlog.DataAccessLayer.Repositories;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.EntityFramework
{
    public class EfNewsletterDal : GenericRepository<Newsletter>, INewsletterDal
    {
        public EfNewsletterDal(SensiveContext context) : base(context)
        {
        }
    }
}
