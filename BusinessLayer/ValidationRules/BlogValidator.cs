using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Please write the blogtitle.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Please write the blog contemt.");

            //image dosya yolu ile belirteceğiz.
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Please write the blog image.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Please enter data less than 150 characters.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Please enter data more than 4 characters.");


        }
    }
}
