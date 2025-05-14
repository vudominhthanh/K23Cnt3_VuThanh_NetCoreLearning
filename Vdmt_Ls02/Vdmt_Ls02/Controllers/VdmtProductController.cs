using Microsoft.AspNetCore.Mvc;

namespace Vdmt_Ls02.Controllers
{
    public class VdmtProductController : Controller
    {
        public IActionResult Vdmt()
        {
            ViewData["messageData"] = "Du lieu tu ViewData";
            ViewBag.messageBag = "Du lieu tu ViewBag";
            TempData["TempData"] = "Du lieu tu TempData";
            return View();
        }
    }
}
