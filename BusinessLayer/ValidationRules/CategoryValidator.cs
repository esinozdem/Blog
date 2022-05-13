using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You cannot leave the Category Name empty!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("You cannot leave the Category Description empty!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Category Name must be a maximum of 50 characters.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Category Name must be a minimum of 50 characters.");
        }
    }
}
