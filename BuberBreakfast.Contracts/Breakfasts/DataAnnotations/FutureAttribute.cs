using System.ComponentModel.DataAnnotations;

namespace BuberBreakfast.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FutureAttribute : ValidationAttribute
    {
        // public override bool IsValid(object? value)
        // {
        //     return value is DateTime dateTime && dateTime > DateTime.UtcNow;
        // }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value is DateTime dateTime && dateTime > DateTime.UtcNow ? ValidationResult.Success : new ValidationResult("Date must be in the future");
        }
    }
}