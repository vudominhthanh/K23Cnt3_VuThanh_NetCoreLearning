using Microsoft.AspNetCore.Mvc;
using VdmtLs04.Models;

namespace VdmtLs04.Controllers
{
    public class VdmtBookController : Controller
    {
        private List<VdmtBook> VdmtBooks = new List<VdmtBook>
            {
                new VdmtBook
                {
                    VdmtId = 1,
                    VdmtTitle = "Clean Code",
                    VdmtDescription = "A Handbook of Agile Software Craftsmanship by Robert C. Martin.",
                    VdmtImage = "error",
                    VdmtPrice = 29.99f,
                    VdmtPage = "464"
                },
                new VdmtBook
                {
                    VdmtId = 2,
                    VdmtTitle = "The Pragmatic Programmer",
                    VdmtDescription = "Your Journey to Mastery, 20th Anniversary Edition.",
                    VdmtImage = "error",
                    VdmtPrice = 35.50f,
                    VdmtPage = "352"
                },
                new VdmtBook
                {
                    VdmtId = 3,
                    VdmtTitle = "Design Patterns",
                    VdmtDescription = "Elements of Reusable Object-Oriented Software by the Gang of Four.",
                    VdmtImage = "error",
                    VdmtPrice = 42.00f,
                    VdmtPage = "395"
                },
                new VdmtBook
                {
                    VdmtId = 4,
                    VdmtTitle = "Artificial Intelligence: A Modern Approach",
                    VdmtDescription = "Comprehensive textbook on AI by Stuart Russell and Peter Norvig.",
                    VdmtImage = "error",
                    VdmtPrice = 89.99f,
                    VdmtPage = "1152"
                },
                new VdmtBook
                {
                    VdmtId = 5,
                    VdmtTitle = "Python Crash Course",
                    VdmtDescription = "A Hands-On, Project-Based Introduction to Programming by Eric Matthes.",
                    VdmtImage = "error",
                    VdmtPrice = 27.99f,
                    VdmtPage = "544"
                }
            };
        public IActionResult VdmtBook()
        {
            return View(VdmtBooks);
        }
        public IActionResult VdmtCreate()
        {
            VdmtBook vdmtBook = new VdmtBook();
            return View();
        }
        [HttpPost]
        public IActionResult VdmtCreateSubmit(VdmtBook book)
        {
            book.VdmtId = VdmtBooks.Count + 1;
            VdmtBooks.Add(book);
            return RedirectToAction("VdmtBook");
        }

        public IActionResult VdmtEdit(string id)
        {
            return View();
        }
        public IActionResult VdmtEditSubmit()
        {
            return RedirectToAction("VdmtBook");
        }
    }
}
