using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Vdmt_Lap8.Models;

namespace Vdmt_Lap8.Controllers
{
    public class VdmtAccountController : Controller
    {
        private static List<VdmtAccount> accounts = new List<VdmtAccount>();
        // GET: HomeController
        public ActionResult Index()
        {
            return View(accounts);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VdmtAccount account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    accounts.Add(account);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyPhone(string VdmtPhone)
        {
            if(string.IsNullOrEmpty(VdmtPhone))
    {
                return Json("Số điện thoại không được để trống.");
            }

            Regex _isPhone = new Regex(@"^(\(?[0-9]{3}\)?)[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            if (!_isPhone.IsMatch(VdmtPhone))
            {
                return Json($"Số điện thoại {VdmtPhone} không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }

            return Json(true);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
