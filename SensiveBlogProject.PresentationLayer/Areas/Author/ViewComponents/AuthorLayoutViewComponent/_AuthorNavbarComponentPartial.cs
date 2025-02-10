using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.ViewComponents.AuthorLayoutViewComponent
{
    public class _AuthorNavbarComponentPartial : ViewComponent
    {
        private readonly IAppUserService _appUserService;

        public _AuthorNavbarComponentPartial(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _appUserService.TGetAppUserInfo();
            return View(value);
        }
    }
}
