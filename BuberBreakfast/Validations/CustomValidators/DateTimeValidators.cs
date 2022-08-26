using FluentValidation;

namespace BuberBreakfast.Validations.CustomValidators
{
    public static class DateTimeValidators
    {
        public static IRuleBuilderOptions<T, DateTime> AfterSunrise<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            var sunrise = TimeOnly.MinValue.AddHours(6);

            // return ruleBuilder.Must(x => TimeOnly.FromDateTime(x) > sunrise);
            return ruleBuilder.Must((objectRoot, dateTime, context) =>
            {
                TimeOnly providedTime = TimeOnly.FromDateTime(dateTime);

                context.MessageFormatter.AppendArgument("Sunrise", sunrise.ToString("hh:mm tt"));
                context.MessageFormatter.AppendArgument("ProvidedTime", providedTime.ToString("hh:mm tt"));

                return providedTime > sunrise;
            })
        .WithMessage("{PropertyName} debe ser despues de {Sunrise}. Ingresaste {ProvidedTime}");
        }
    }
}