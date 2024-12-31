using Microsoft.Extensions.DependencyInjection;
using SensiveBlog.BusinessLayer.Abstract;
using SensiveBlog.BusinessLayer.Concrete;
using SensiveBlog.DataAccessLayer.Abstract;
using SensiveBlog.DataAccessLayer.EntityFramework;

namespace SensiveBlog.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            //Bu yapı registiration
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<IArticleService, ArticleManager>();

            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            
            services.AddScoped<INewsletterDal, EfNewsletterDal>();
            services.AddScoped<INewsletterService, NewsletterManager>();
        }
    }
}
