using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;

namespace  ProjectShifts.Controllers
{
    public class UsersController : Controller
    {
        public readonly ProjectShiftsContext _context;

        public UsersController (ProjectShiftsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

    }

}