using BuberBreakfast.Contracts.Breakfasts;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    public class BreakfastsController : ApiController
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfastCreateResult = Breakfast.From(request);

            if (breakfastCreateResult.IsError)
            {
                return Problem(breakfastCreateResult.Errors);
            }

            var breakfast = breakfastCreateResult.Value;

            var createResult = _breakfastService.CreateBreakfast(breakfast);

            if (createResult.IsError)
            {
                return Problem(createResult.Errors);
            }

            var response = MapBreakfastResponse(breakfast);

            return CreatedAtAction(nameof(GetBreakfast), new { id = response.Id }, response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult
                .Match(breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBreakfast(Guid id, UpdateBreakfastRequest request)
        {
            var breakfastCreateResult = Breakfast.From(request, id);

            if (breakfastCreateResult.IsError)
            {
                return Problem(breakfastCreateResult.Errors);
            }

            var breakfast = breakfastCreateResult.Value;

            var updateResult = _breakfastService.UpdateBreakfast(breakfast);

            return updateResult.Match(updated => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            var deleteResult = _breakfastService.DeleteBreakfast(id);

            return deleteResult
                .Match(deleted => NoContent(), errors => Problem(errors));
        }

        private static BreakfastResponse
        MapBreakfastResponse(Breakfast breakfast)
        {
            return new BreakfastResponse(breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModfiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);
        }
    }
}
