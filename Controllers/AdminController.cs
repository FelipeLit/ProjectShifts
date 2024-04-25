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

        public async Task<IActionResult> Dashboard()
        {
            return View(await _context.Turnos.ToListAsync());
        }

        public async Task<IActionResult> Attend(int id)
        {
            var shift = await _context.Turnos.FindAsync(id);

            shift.FechaAtencion = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Finish(int id)
        {
            var shift = await _context.Turnos.FindAsync(id);

            shift.FechaFin = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }
    }
}