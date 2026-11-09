using Microsoft.AspNetCore.Mvc;
using RaceDay.Web.Services;

namespace RaceDay.Web.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly ApiService _apiService;

        public OrganiserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Dashboard()
        {
            // Optional: Fetch organiser's events from the API
            // var events = await _apiService.GetAsync<List<EventDto>>("api/events/organiser");
            return View();
        }

        [HttpGet]
        public IActionResult CreateEvent() => View();

        [HttpPost]
        public async Task<IActionResult> CreateEvent(string name, string description, DateTime date, string location, decimal distance, IFormFile bannerImage)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(name), "Name");
            content.Add(new StringContent(description), "Description");
            content.Add(new StringContent(date.ToString("o")), "Date");
            content.Add(new StringContent(location), "Location");
            content.Add(new StringContent(distance.ToString()), "Distance");

            if (bannerImage != null)
            {
                var fileStream = new StreamContent(bannerImage.OpenReadStream());
                content.Add(fileStream, "BannerImage", bannerImage.FileName);
            }

            var response = await _apiService.PostMultipartAsync("api/events", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard");
            }

            ModelState.AddModelError("", "Failed to create event.");
            return View();
        }
    }
}
