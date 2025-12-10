using MRL.Shared.Contracts;

namespace MRL.Website.ViewModel
{
    public class ReviewsIndexViewModel
    {
        public List<MotorcycleDTO> Motorcycles { get; set; } = [];
        public string? SelectedMetric { get; set; }
        public int? SelectedMotorcycleId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

}
