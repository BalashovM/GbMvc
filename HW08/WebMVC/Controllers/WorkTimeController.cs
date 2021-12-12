using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class WorkTimeController : Controller
    {
        private readonly ILogger<WorkTimeController> _logger;

        public WorkTimeController(ILogger<WorkTimeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new WorkTimeViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
