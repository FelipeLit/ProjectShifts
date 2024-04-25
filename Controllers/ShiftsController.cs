using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;

namespace ProjectShifts.Controllers
{
    public class ShiftsController : Controller
    {
        public readonly ProjectShiftsContext _context;

        public ShiftsController(ProjectShiftsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Turnos.ToListAsync());
        }
    }
}