using Microsoft.AspNetCore.Mvc;
using Vdmt_Ls05.Models;

namespace Vdmt_Ls05.Controllers
{
    public class VdmtMemberController : Controller
    {
        private static List<VdmtMembers> vdmtListMembers = new List<VdmtMembers>()
        {
            new VdmtMembers
            {
                VdmtMemberId = "2310900099",
                VdmtUserName = "Thanhvu",
                VdmtPassword = "Thanhvu123",
                VdmtFullName = "Vu Do Minh Thanh",
                VdmtEmail = "tawoz1311y@gmail.com"
            },
            new VdmtMembers
            {
                VdmtMemberId = "002",
                VdmtUserName = "user2",
                VdmtPassword = "pass2",
                VdmtFullName = "Tran Thi B",
                VdmtEmail = "user2@example.com"
            },
            new VdmtMembers
            {
                VdmtMemberId = "003",
                VdmtUserName = "user3",
                VdmtPassword = "pass3",
                VdmtFullName = "Le Van C",
                VdmtEmail = "user3@example.com"
            },
            new VdmtMembers
            {
                VdmtMemberId = "004",
                VdmtUserName = "user4",
                VdmtPassword = "pass4",
                VdmtFullName = "Pham Thi D",
                VdmtEmail = "user4@example.com"
            },
            new VdmtMembers
            {
                VdmtMemberId = "005",
                VdmtUserName = "user5",
                VdmtPassword = "pass5",
                VdmtFullName = "Hoang Van E",
                VdmtEmail = "user5@example.com"
            }
        };  
        public IActionResult Index()
        {
            return View(vdmtListMembers);
        }
    }
}
