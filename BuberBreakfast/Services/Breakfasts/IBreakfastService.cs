using BuberBreakfast.Contracts.Breakfasts;
using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast breakfast);

        ErrorOr<Breakfast> GetBreakfast(Guid id);

        ErrorOr<Deleted> DeleteBreakfast(Guid id);

        ErrorOr<Updated> UpdateBreakfast(Breakfast breakfast);
    }
}
