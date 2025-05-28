using Microsoft.AspNetCore.Mvc;
using VdmtLs6.Models;

namespace VdmtLs6.Controllers
{
    public class VdmtEmployeeController : Controller
    {
        private static List<VdmtEmplyee> vdmtListEmployees = new List<VdmtEmplyee>()
        {
            new VdmtEmplyee
            {
                VdmtId = 099,
                VdmtName = "Vu Do Minh Thanh",
                VdmtBirthDay = new DateTime(2005, 11, 13),
                VdmtEmail = "tawoz131105@gmail.com",
                VdmtPhone = 0123456789,
                VdmtSalary = 15000000,
                VdmtStatus = true
            },
            new VdmtEmplyee
            {
                VdmtId = 2,
                VdmtName = "Tran Thi B",
                VdmtBirthDay = new DateTime(1988, 8, 20),
                VdmtEmail = "b.tran@example.com",
                VdmtPhone = 0987654321,
                VdmtSalary = 12000000,
                VdmtStatus = true
            },
            new VdmtEmplyee
            {
                VdmtId = 3,
                VdmtName = "Le Van C",
                VdmtBirthDay = new DateTime(1995, 1, 5),
                VdmtEmail = "c.le@example.com",
                VdmtPhone = 0934567890,
                VdmtSalary = 10000000,
                VdmtStatus = false
            },
            new VdmtEmplyee
            {
                VdmtId = 4,
                VdmtName = "Pham Thi D",
                VdmtBirthDay = new DateTime(1992, 9, 15),
                VdmtEmail = "d.pham@example.com",
                VdmtPhone = 0978123456,
                VdmtSalary = 17000000,
                VdmtStatus = true
            },
            new VdmtEmplyee
            {
                VdmtId = 5,
                VdmtName = "Hoang Van E",
                VdmtBirthDay = new DateTime(1991, 12, 30),
                VdmtEmail = "e.hoang@example.com",
                VdmtPhone = 0967890123,
                VdmtSalary = 13000000,
                VdmtStatus = false
            }
        };
        public IActionResult VdmtListEmployee()
        {
            return View(vdmtListEmployees);
        }

        public IActionResult VdmtCreate()
        {
            VdmtEmplyee employee = new VdmtEmplyee();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VdmtCreate(VdmtEmplyee employee)
        {
            if (ModelState.IsValid)
            {
                employee.VdmtId = vdmtListEmployees.Max(e => e.VdmtId) + 1;
                vdmtListEmployees.Add(employee);
                return RedirectToAction("VdmtListEmployee");
            }
            return View(employee);
        }

        public IActionResult VdmtEdit(int vdmtid)
        {
            var emp = vdmtListEmployees.FirstOrDefault(e => e.VdmtId == vdmtid);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VdmtEdit(int vdmtid, VdmtEmplyee employee)
        {
            if (vdmtid != employee.VdmtId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var emp = vdmtListEmployees.FirstOrDefault(e => e.VdmtId == vdmtid);
                if (emp == null)
                    return NotFound();

                emp.VdmtName = employee.VdmtName;
                emp.VdmtBirthDay = employee.VdmtBirthDay;
                emp.VdmtEmail = employee.VdmtEmail;
                emp.VdmtPhone = employee.VdmtPhone;
                emp.VdmtSalary = employee.VdmtSalary;
                emp.VdmtStatus = employee.VdmtStatus;

                return RedirectToAction("VdmtListEmployee");
            }
            return View(employee);
        }

        public IActionResult VdmtDelete(int vdmtid)
        {
            var emp = vdmtListEmployees.FirstOrDefault(e => e.VdmtId == vdmtid);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("VdmtDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult VdmtDeleteConfirmed(int vdmtid)
        {
            var emp = vdmtListEmployees.FirstOrDefault(e => e.VdmtId == vdmtid);
            if (emp != null)
                vdmtListEmployees.Remove(emp);
            return RedirectToAction("VdmtListEmployee");
        }
    }
}
