using BuberBreakfast.Contracts.Breakfasts;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 50;
        public const int MaxDescriptionLength = 150;

        private Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModfiedDateTime, List<string> savory, List<string> sweet)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.LastModfiedDateTime = lastModfiedDateTime;
            this.Savory = savory;
            this.Sweet = sweet;

        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModfiedDateTime { get; }
        public List<string> Savory { get; }
        public List<string> Sweet { get; }

        public static ErrorOr<Breakfast> Create(string name, string description, DateTime startDateTime, DateTime endDateTime, List<string> savory, List<string> sweet, Guid? id = null)
        {
            return new Breakfast(id ?? Guid.NewGuid(), name, description, startDateTime, endDateTime, DateTime.UtcNow, savory, sweet);
        }

		public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
		{
			return Create(request.Name, request.Description, request.StartDateTime, request.EndDateTime, request.Savory, request.Sweet);
		}

		
		public static ErrorOr<Breakfast> From(UpdateBreakfastRequest request, Guid id)
		{
			return Create(request.Name, request.Description, request.StartDateTime, request.EndDateTime, request.Savory, request.Sweet, id);
		}
    }
}