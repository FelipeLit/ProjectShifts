namespace ProjectShifts.Models
{
    public class Usuarios
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public  int IdTipoDocumento { get; set; }
    }
}