using FluentValidation;
using Open.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open.Consola.Validators
{
    public class ShoesValidator:AbstractValidator<Shoe>
    {
        public ShoesValidator()
        {
            RuleFor(s => s.Model).NotEmpty().WithMessage("The {PropertyName} is required")
                .MaximumLength(300).WithMessage("The {PropertyName} must have no more than {ComparisonValue} characters");

            RuleFor(s => s.Size).NotEmpty().WithMessage("The {PropertyName} is required")
                .GreaterThan(0).WithMessage("The {PropertyName} must be greather than {ComparisonValue}");

            RuleFor(s => s.Release).NotEmpty().WithMessage("The {PropertyName} is required")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today.Date)).WithMessage("The {PropertyName} must be at least {ComparisonValue}");
        }
    }
}
