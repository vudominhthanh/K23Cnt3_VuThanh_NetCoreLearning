using Microsoft.AspNetCore.Mvc;
using VdmtLs9.Data;
using VdmtLs9.Models; 

namespace VdmtLs9.Controllers
{

    public class BookStoreController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookStoreController(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
    }
}
