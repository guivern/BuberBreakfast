namespace BuberBreakfast.Contracts.Breakfasts
{
    public record UpdateBreakfastRequest(
      string Name,
      string Description,
      DateTime StartDateTime,
      DateTime EndDateTime,
      List<string> Savory,
      List<string> Sweet);
}