using FluentValidation;
using SensiveBlog.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.BusinessLayer.ValidationRules.CategoryValidationRules
{
    public class CreateCategoryValidator : AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilmez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen en fazla 3 karakter veri girişi yapınız.");
        }
    }
}
