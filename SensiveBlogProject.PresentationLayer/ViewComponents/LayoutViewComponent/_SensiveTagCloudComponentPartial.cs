using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensiveTagCloudComponentPartial : ViewComponent
    {
        private readonly ITagCloudService _tagCloudService;

        public _SensiveTagCloudComponentPartial(ITagCloudService tagCloudService)
        {
            _tagCloudService = tagCloudService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _tagCloudService.TGetAll();
            return View(value);
        }
    }
}
