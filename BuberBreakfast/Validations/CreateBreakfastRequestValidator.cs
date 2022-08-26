using BuberBreakfast.Contracts.Breakfasts;
using BuberBreakfast.Validations.CustomValidators;
using FluentValidation;

namespace BuberBreakfast.Validations
{
    public class CreateBreakfastRequestValidator: AbstractValidator<CreateBreakfastRequest>
    {
        public CreateBreakfastRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} es requerido.").MinimumLength(3).MaximumLength(10);
            RuleFor(x => x.StartDateTime).Must(x => x > DateTime.Now).WithMessage("Debe ser mayor que la fecha actual").AfterSunrise();
            RuleFor(x => x.EndDateTime).GreaterThan(x => x.StartDateTime).WithMessage("Debe ser mayor que la fecha de inicio.");
            RuleFor(x => x.Savory).Must(x => x.Count > 0).WithMessage("{PropertyName} debe contener al menos un elemento");
            RuleFor(x => x.Sweet).Must(x => x.Count > 0).WithMessage("{PropertyName} debe contener al menos un elemento");
        }
    }
}