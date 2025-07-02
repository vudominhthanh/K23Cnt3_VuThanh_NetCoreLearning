using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vdmt_Lesson11.Models;

namespace Vdmt_Lesson11.Controllers
{
    public class vdmtHomeController : Controller
    {
        private readonly ILogger<vdmtHomeController> _logger;

        public vdmtHomeController(ILogger<vdmtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult VdmtIndex()
        {
            return View();
        }

        public IActionResult VdmtAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
