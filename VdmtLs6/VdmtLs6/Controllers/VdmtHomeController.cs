using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VdmtLs6.Models;

namespace VdmtLs6.Controllers
{
    public class VdmtHomeController : Controller
    {
        private readonly ILogger<VdmtHomeController> _logger;

        public VdmtHomeController(ILogger<VdmtHomeController> logger)
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
