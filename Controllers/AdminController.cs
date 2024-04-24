using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;

namespace  ProjectShifts.Controllers
{
    public class AdminController : Controller
    {
        public readonly ProjectShiftsContext _context;

        public AdminController (ProjectShiftsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

    }

}