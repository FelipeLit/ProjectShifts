using Microsoft.EntityFrameworkCore;
using ProjectShifts.Models;
namespace ProjectShifts.Data
{
    public class ProjectShiftsContext : DbContext
    {
        public ProjectShiftsContext(DbContextOptions<ProjectShiftsContext> options) : base (options)
        {

        }
        
        public DbSet <Administrador> Administrador { get; set;}
        public DbSet <Usuarios> Usuarios { get; set;}
        public DbSet <Turnos> Turnos { get; set;}
        public DbSet <TipoDocumento> TipoDocumento { get; set;}
        public DbSet <TipoTurno> TipoTurno { get; set;}
    }
}