using System.ComponentModel.DataAnnotations;
using BuberBreakfast.DataAnnotations;

namespace BuberBreakfast.Contracts.Breakfasts
{
    //      Data Annotations approach
    //     public record CreateBreakfastRequest(
    //         [MinLength(3), MaxLength(20)]
    //         string Name,
    //         string Description,
    //         [Future] DateTime StartDateTime,
    //         [Future] DateTime EndDateTime,
    //         List<string> Savory,
    //         List<string> Sweet);

    public record CreateBreakfastRequest(
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet);

}