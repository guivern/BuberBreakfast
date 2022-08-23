using ErrorOr;

namespace BuberBreakfast.ServiceErrors
{
    public static class BreakfastErrors
    {
        public static Error NotFound =>
            Error
                .NotFound(code: "Breakfast.NotFound",
                description: "Breakfast Not Found");
    }
}
