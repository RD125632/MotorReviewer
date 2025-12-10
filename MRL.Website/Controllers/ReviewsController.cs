using Microsoft.AspNetCore.Mvc;
using MRL.Shared.Contracts;
using MRL.Website.ViewModel;

namespace MRL.Website.Controllers
{
    public class ReviewsController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("MotorcycleReviewsApi");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var motorcycles = await client.GetFromJsonAsync<List<MotorcycleDTO>>("api/motorcycle") ?? [];
            var vm = new ReviewsIndexViewModel
            {
                Motorcycles = motorcycles
            };
            return View(vm);
        }

        // JSON endpoint for chart
        [HttpGet]
        public async Task<IActionResult> ChartData(
            int? motorcycleId,
            DateTime? from,
            DateTime? to,
            string metric = "Overall")
        {
            var client = CreateClient();

            // Build query string for API call
            var queryParams = new List<string>();

            if (motorcycleId.HasValue) queryParams.Add($"motorcycleId={motorcycleId.Value}");
            if (from.HasValue) queryParams.Add($"from={from.Value:O}"); // ISO 8601
            if (to.HasValue) queryParams.Add($"to={to.Value:O}");

            var url = "api/review";
            if (queryParams.Count != 0)
                url += "?" + string.Join("&", queryParams);

            // Call WebAPI
            var reviews = await client.GetFromJsonAsync<List<ReviewDTO>>(url) ?? [];
            var motorcycles = await client.GetFromJsonAsync<List<MotorcycleDTO>>("api/motorcycle") ?? [];
            var brands = await client.GetFromJsonAsync<List<BrandDTO>>("api/brand") ?? [];

            var grouped = reviews
                .GroupBy(r => r.MotorcycleId)
                .OrderBy(g => g.Key)
                .ToList();

            var labels = reviews
                .OrderBy(r => r.ReviewDate)
                .Select(r => r.ReviewDate.Date)
                .Distinct()
                .Select(d => d.ToString("yyyy-MM-dd"))
                .ToList();

            // Group by date, compute avg of selected metric
            var datasets = grouped.Select(g =>
            {
                var motorcycleDTO = motorcycles.First(m => m.Id == g.First().MotorcycleId);
                var brandDTO = brands.First(m => m.Id == motorcycleDTO.BrandId);
                var motorcycleName = brandDTO.Name + " " + motorcycleDTO.Model;

                // Build a dictionary date → value so we can align with labels
                var points = g.ToDictionary(
                    r => r.ReviewDate.Date,
                    r => metric switch
                    {
                        "Handling" => r.HandlingScore,
                        "Engine" => r.EngineScore,
                        "Comfort" => r.ComfortScore,
                        "Brakes" => r.BrakesScore,
                        "Stability" => r.StabilityScore,
                        "Value" => r.ValueScore,
                        "Overall" or _ => r.OverallScore
                            ?? (r.HandlingScore + r.EngineScore + r.ComfortScore +
                                r.BrakesScore + r.StabilityScore + r.ValueScore) / 6m
                    }
                );

                // Align values to labels:
                var values = labels
                    .Select(lbl => DateTime.Parse(lbl))
                    .Select(date => points.TryGetValue(date, out var v) ? v : (decimal?)null)
                    .ToList();

                return new
                {
                    label = motorcycleName,
                    data = values
                };
            }).ToList();

            return Json(new
            {
                labels,
                datasets
            });
        }
    }
}