namespace ProjectShifts.Models
{
        public class Turnos
    {
        public int Id { get; set;}
        public string CodigoTurno { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdTipoTurno { get; set; }
        public  int IdUsuario { get; set; }
        public  int? IdAdministrador { get; set; }
    }
}