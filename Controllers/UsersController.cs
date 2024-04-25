using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;
using ProjectShifts.Models;

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
        public async Task<IActionResult> LoginUser(string documento, int tipoDocumento)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.NumeroDocumento == documento);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Categories", "Users");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Generar(string turno, int id)
        {
            int contador = Request.Cookies.ContainsKey("Contador") ? int.Parse(Request.Cookies["Contador"]) : 0;
            var idTipoTurno = id;

            contador++;
            string ficho = $"{turno}-{(contador < 10 ? "00" + contador : "0" + contador)}";

            //nods da la cookie con el valor del contador
            Response.Cookies.Append("Contador", contador.ToString());

            //ViewBag.Usuario = HttpContext.Session.GetString("User");
            HttpContext.Session.SetInt32("TipoTurno", idTipoTurno);

            ViewBag.Ficho = ficho;

            return View("Turno");
        }

         public IActionResult Turno()
        {
            return View();
        }

        public async Task<IActionResult> TomarTurno(string turno)
        {
            string usuario = HttpContext.Session.GetString("User");
            var id = HttpContext.Session.GetInt32("UserId");
            var NumeroTurno = turno;

            if (id != null)
            {
                var saveTurno = new Turnos
                {
                    IdUsuario = id.Value,
                    FechaInicio = DateTime.Now,
                    CodigoTurno = NumeroTurno,
                    IdTipoTurno = HttpContext.Session.GetInt32("TipoTurno").Value,
                };
    
                _context.Turnos.Add(saveTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Users");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }
        }

    }

}
