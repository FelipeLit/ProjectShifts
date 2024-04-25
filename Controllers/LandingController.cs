using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;

namespace  ProjectShifts.Controllers
{
    public class LandingController : Controller
    {
        public readonly ProjectShiftsContext _context;

        public LandingController (ProjectShiftsContext context)
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