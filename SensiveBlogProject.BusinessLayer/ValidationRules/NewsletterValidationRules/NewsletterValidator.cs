using FluentValidation;
using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.BusinessLayer.ValidationRules.NewsletterValidationRules
{
    public class NewsletterValidator : AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi gereklidir!");
            //RuleFor(x => x.Email).EmailAddress().WithMessage("@");
        }
    }
}
