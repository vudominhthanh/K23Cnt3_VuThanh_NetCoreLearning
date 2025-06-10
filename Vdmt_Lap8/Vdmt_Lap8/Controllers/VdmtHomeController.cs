using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vdmt_Lap8.Models;

namespace Vdmt_Lap8.Controllers
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
