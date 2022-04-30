using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer FullName cannot be empty.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Email connot be empty");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password connot be empty");
            RuleFor(x => x.WriterImage).MinimumLength(2).WithMessage("Please enter at least two characters.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Please enter up to fifty characters.");
        }
    }
}
