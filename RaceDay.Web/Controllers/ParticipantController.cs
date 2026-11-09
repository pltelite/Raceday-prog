using Microsoft.AspNetCore.Mvc;
using RaceDay.Web.Services;

namespace RaceDay.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ApiService _apiService;

        public ParticipantController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Participant/Index (Home page showing all upcoming events)
        public async Task<IActionResult> Index()
        {
            // Fetches events from your Part 2 Web API endpoint
            var events = await _apiService.GetAsync<List<EventViewModel>>("api/events");
            return View(events ?? new List<EventViewModel>());
        }

        // GET: /Participant/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _apiService.GetAsync<EventViewModel>($"api/events/{id}");
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

        // POST: /Participant/Enroll
        [HttpPost]
        public async Task<IActionResult> Enroll(int eventId, int categoryId)
        {
            var enrollmentDto = new { EventId = eventId, CategoryId = categoryId };
            var response = await _apiService.PostAsync("api/enrollments", enrollmentDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MyEnrollments");
            }

            ModelState.AddModelError("", "Could not complete enrolment.");
            return RedirectToAction("Details", new { id = eventId });
        }

        // GET: /Participant/MyEnrollments
        public async Task<IActionResult> MyEnrollments()
        {
            var enrollments = await _apiService.GetAsync<List<EnrollmentViewModel>>("api/enrollments/my");
            return View(enrollments ?? new List<EnrollmentViewModel>());
        }

        // GET: /Participant/MyResults
        public async Task<IActionResult> MyResults()
        {
            var results = await _apiService.GetAsync<List<ResultViewModel>>("api/results/my");
            return View(results ?? new List<ResultViewModel>());
        }
    }
}
