using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
        public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);

            return Result.Created;
        }

        public ErrorOr<Deleted> DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);

            return Result.Deleted;
        }

        public ErrorOr<Breakfast> GetBreakfast(Guid id)
        {
            if (_breakfasts.TryGetValue(id, out var breakfast))
                return breakfast;

            return BreakfastErrors.NotFound;
        }

        public ErrorOr<Updated> UpdateBreakfast(Breakfast breakfast)
        {
            if (!_breakfasts.ContainsKey(breakfast.Id))
                return BreakfastErrors.NotFound;

            _breakfasts[breakfast.Id] = breakfast;

            return Result.Updated;
        }
    }
}