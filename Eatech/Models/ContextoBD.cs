using Eatech.Models;
using Microsoft.EntityFrameworkCore;

namespace Eatech.Models
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> opt) : base(opt) { }

        //Tablas de nuestra base de datos
        public DbSet<Bd_Usuario> Usuarios { get; set; }
        public DbSet<Bd_Comida> Comidas { get; set; }
        public DbSet<Bd_Ingredientes> Ingredientes { get; set; }
        public DbSet<Bd_Pedido> Pedidos { get; set; }
        public DbSet<Bd_Alumno> Alumnos { get; set; }
        public DbSet<Bd_Ex_LicenciaAdmin> LicenciaAdmin{ get; set; }
        public DbSet<BdI_Alu_Ped> Intermedia_Alum_Pedi { get; set; }
        public DbSet<BdI_Com_Ingr> Intermedia_Comida_Ingre { get; set; }
        public DbSet<BdI_Com_Ped> Intermedia_Comida_Pedi { get; set; }
        public DbSet<BdI_Usu_Alum> Intermedia_Usuario_Alumno { get; set; }
    }
}
