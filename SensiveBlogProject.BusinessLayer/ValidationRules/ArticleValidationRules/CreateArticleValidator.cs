using FluentValidation;
using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.BusinessLayer.ValidationRules.ArticleValidationRules
{
    public class CreateArticleValidator:AbstractValidator<Article>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen en az 1 karakter giriniz!");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz!");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Kategori seçiniz!");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen en az 200 karakter giriniz!");
        }
    }
}
