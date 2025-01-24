using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.DataAccessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents
{
    public class CategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryDal categoryDal;
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
