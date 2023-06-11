using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.WriterPasword).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("2 karaterten az olamaz");
            RuleFor(x => x.WriterName).MaximumLength(52).WithMessage("52 karaterten çok olamaz");


        }

    }
}
