using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ProjectShifts.Controllers
{
    public class AdminController : Controller
    {
        public readonly ProjectShiftsContext _context;

        public AdminController(ProjectShiftsContext context)
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
            var adminId = HttpContext.Session.GetInt32("UserId");

            shift.FechaAtencion = DateTime.Now;
            shift.IdAdministrador = adminId;
            await _context.SaveChangesAsync();

            await VoiceShifts(shift.CodigoTurno);

            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Finish(int id)
        {
            var shift = await _context.Turnos.FindAsync(id);

            shift.FechaFin = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> LoginAdmin(string correo, string password)
        {
            var user = await _context.Administrador.FirstOrDefaultAsync(u => u.Correo == correo);
            if (user != null)
            {
                if (user.Contrasena == password)
                {
                    HttpContext.Session.SetString("User", user.Nombre);
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("Dashboard", "Admin");
                }
                TempData["errorMessage"] = "Correo electrónico o contraseña incorrectos";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["errorMessage"] = "Correo electrónico o contraseña incorrectos";
                return RedirectToAction("Index", "Admin");
            }
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> VoiceShifts(string turno)
        {
            var turnoUsuario = await _context.Turnos.FirstOrDefaultAsync(t=>t.CodigoTurno == turno);
            
          // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.
            synth.SetOutputToDefaultAudioDevice();

            synth.Speak(turnoUsuario.CodigoTurno);

            // Speak a string asynchronously
            var prompt = synth.SpeakAsync(turnoUsuario.CodigoTurno);

            while (!prompt.IsCompleted)
            {
                Thread.Sleep(500);
            }

            return RedirectToAction("Dashboard");
        }

    }
}