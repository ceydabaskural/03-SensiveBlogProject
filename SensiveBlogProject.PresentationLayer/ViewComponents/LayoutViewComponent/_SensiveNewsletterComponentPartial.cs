using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.BusinessLayer.Concrete;
using SensiveBlogProject.BusinessLayer.ValidationRules.CategoryValidationRules;
using SensiveBlogProject.BusinessLayer.ValidationRules.NewsletterValidationRules;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.ViewComponents.LayoutViewComponent
{
    public class _SensiveNewsletterComponentPartial : ViewComponent
    {
        private readonly INewsletterService _newsletterService;

        public _SensiveNewsletterComponentPartial(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public IViewComponentResult Invoke()
        {
            var newsLetter = new Newsletter(); // Gerekirse buradan model doldurulur
            return View(newsLetter);

            //ModelState.Clear(); //hata mesajlarını türkçe yazdırmasını sağladık    
            //NewsletterValidator validationRules = new NewsletterValidator();
            //ValidationResult result = validationRules.Validate(newsletter);//newsletter gelen değerlerin geçerliliği kontrol edilecek
            //if (result.IsValid)
            //{
            //    _newsletterService.TInsert(newsletter);
            //    return View("Index","Default");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //    return View();
            ////}
            //return View();
        }

    }
}
