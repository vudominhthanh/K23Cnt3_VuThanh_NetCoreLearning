using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vudominnhthanh_2310900099.Models;

namespace vudominnhthanh_2310900099.Controllers
{
    public class VdmtEmployeesController : Controller
    {
        private readonly Vudominhthanh2310900099Context _context;

        public VdmtEmployeesController(Vudominhthanh2310900099Context context)
        {
            _context = context;
        }

        // GET: VdmtEmployees
        public async Task<IActionResult> VdmtIndex()
        {
            return View(await _context.VdmtEmployees.ToListAsync());
        }

        // GET: VdmtEmployees/Details/5
        public async Task<IActionResult> VdmtDetails(string VdmtId)
        {
            if (VdmtId == null)
            {
                return NotFound();
            }

            var vdmtEmployee = await _context.VdmtEmployees
                .FirstOrDefaultAsync(m => m.VdmtEmpId == VdmtId);
            if (vdmtEmployee == null)
            {
                return NotFound();
            }

            return View(vdmtEmployee);
        }

        // GET: VdmtEmployees/Create
        public IActionResult VdmtCreate()
        {
            return View();
        }

        // POST: VdmtEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VdmtCreate([Bind("VdmtEmpId,VdmtEmpName,VdmtEmpLevel,VdmtEmpStartDate,VdmtEmpstatus")] VdmtEmployee vdmtEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vdmtEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VdmtIndex));
            }
            return View(vdmtEmployee);
        }

        // GET: VdmtEmployees/Edit/5
        public async Task<IActionResult> VdmtEdit(string VdmtId)
        {
            if (VdmtId == null)
            {
                return NotFound();
            }

            var vdmtEmployee = await _context.VdmtEmployees.FindAsync(VdmtId);
            if (vdmtEmployee == null)
            {
                return NotFound();
            }
            return View(vdmtEmployee);
        }

        // POST: VdmtEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VdmtEdit(string VdmtId, [Bind("VdmtEmpId,VdmtEmpName,VdmtEmpLevel,VdmtEmpStartDate,VdmtEmpstatus")] VdmtEmployee vdmtEmployee)
        {
            if (VdmtId != vdmtEmployee.VdmtEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vdmtEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VdmtEmployeeExists(vdmtEmployee.VdmtEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(VdmtIndex));
            }
            return View(vdmtEmployee);
        }

        // GET: VdmtEmployees/Delete/5
        public async Task<IActionResult> VdmtDelete(string VdmtId)
        {
            if (VdmtId == null)
            {
                return NotFound();
            }

            var vdmtEmployee = await _context.VdmtEmployees
                .FirstOrDefaultAsync(m => m.VdmtEmpId == VdmtId);
            if (vdmtEmployee == null)
            {
                return NotFound();
            }

            return View(vdmtEmployee);
        }

        // POST: VdmtEmployees/Delete/5
        [HttpPost, ActionName("VdmtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string VdmtId)
        {
            var vdmtEmployee = await _context.VdmtEmployees.FindAsync(VdmtId);
            if (vdmtEmployee != null)
            {
                _context.VdmtEmployees.Remove(vdmtEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VdmtIndex));
        }

        private bool VdmtEmployeeExists(string VdmtId)
        {
            return _context.VdmtEmployees.Any(e => e.VdmtEmpId == VdmtId);
        }
    }
}
