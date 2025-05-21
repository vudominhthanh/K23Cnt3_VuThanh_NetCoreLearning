using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vdmt_Ls05.Models;

namespace Vdmt_Ls05.Controllers
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

        public IActionResult Privacy()
        {
            VdmtMembers vdmtMembers = new VdmtMembers();
            vdmtMembers.VdmtMemberId = Guid.NewGuid().ToString();
            vdmtMembers.VdmtUserName = "VdmtUserName";
            vdmtMembers.VdmtPassword = "VdmtPassword";
            vdmtMembers.VdmtFullName = "VdmtFullName";
            vdmtMembers.VdmtEmail = "VdmtEmail";    
            return View(vdmtMembers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
