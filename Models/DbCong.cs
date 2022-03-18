using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpresa.Models
{
    public class DbCong : DbContext
    {
        public DbCong(DbContextOptions<DbCong>options):base(options)
        {}
        public virtual DbSet<Direccion>Direciones { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
    }
}
