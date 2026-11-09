namespace RaceDay.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Distance { get; set; }
        public string? BannerImageUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new();
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EnrollmentViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Colour-coded status requirement
    }

    public class ResultViewModel
    {
        public string EventName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string FinishTime { get; set; } = string.Empty;
        public string FinishingPosition { get; set; } = string.Empty; // e.g., "47th out of 312 finishers"
    }
}
