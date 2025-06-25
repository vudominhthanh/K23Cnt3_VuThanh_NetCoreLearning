using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vdmt_Ls10.Models;

namespace Vdmt_Ls10.Controllers
{
    public class VdmtPostsController : Controller
    {
        private readonly VdmtK23cnt3Ls10DbContext _context;

        public VdmtPostsController(VdmtK23cnt3Ls10DbContext context)
        {
            _context = context;
        }

        // GET: VdmtPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.VdmtPosts.ToListAsync());
        }

        // GET: VdmtPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vdmtPost = await _context.VdmtPosts
                .FirstOrDefaultAsync(m => m.Vdmtid == id);
            if (vdmtPost == null)
            {
                return NotFound();
            }

            return View(vdmtPost);
        }

        // GET: VdmtPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VdmtPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vdmtid,VdmtTitle,VdmtImage,VdmtContent,VdmtStatus")] VdmtPost vdmtPost, IFormFile VdmtImage)
        {
            if (ModelState.IsValid)
            {
                if (VdmtImage != null & VdmtImage.Length > 0)
                {

                        var fileName = Path.GetFileNameWithoutExtension(VdmtImage.FileName);
                        var extension = Path.GetExtension(VdmtImage.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                        // Đường dẫn thư mục lưu file ảnh
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                        // Lưu file vào thư mục
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await VdmtImage.CopyToAsync(stream);
                        }

                    // Gán tên file mới vào trường TvcImage của đối tượng TvcPost
                    vdmtPost.VdmtImage = "images/" + newFileName;
                        }
                _context.Add(vdmtPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vdmtPost);
        }

        // GET: VdmtPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vdmtPost = await _context.VdmtPosts.FindAsync(id);
            if (vdmtPost == null)
            {
                return NotFound();
            }
            return View(vdmtPost);
        }

        // POST: VdmtPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int VdmtId, [Bind("Vdmtid,VdmtTitle,VdmtImage,VdmtContent,VdmtStatus")] VdmtPost vdmtPost, IFormFile VdmtImage)
        {
            if (VdmtId != vdmtPost.Vdmtid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (VdmtImage != null && VdmtImage.Length > 0)
                {
                    // Tạo tên file duy nhất để tránh trùng lặp
                    var fileName = Path.GetFileNameWithoutExtension(VdmtImage.FileName);
                    var extension = Path.GetExtension(VdmtImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                    // Đường dẫn thư mục lưu file ảnh
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    // Lưu file vào thư mục
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await VdmtImage.CopyToAsync(stream);
                    }

                    vdmtPost.VdmtImage = "images/" + newFileName;
                }
                try
                {
                    _context.Update(vdmtPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VdmtPostExists(vdmtPost.Vdmtid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vdmtPost);
        }

        // GET: VdmtPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vdmtPost = await _context.VdmtPosts
                .FirstOrDefaultAsync(m => m.Vdmtid == id);
            if (vdmtPost == null)
            {
                return NotFound();
            }

            return View(vdmtPost);
        }

        // POST: VdmtPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int VdmtId)
        {
            var vdmtPost = await _context.VdmtPosts.FindAsync(VdmtId);
            if (vdmtPost != null)
            {
                _context.VdmtPosts.Remove(vdmtPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VdmtPostExists(int id)
        {
            return _context.VdmtPosts.Any(e => e.Vdmtid == id);
        }
    }
}
