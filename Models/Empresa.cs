using System.ComponentModel.DataAnnotations;
namespace AdministracionEmpresa.Models
{
     public partial class Empresa
    {
        public Empresa()
        {
            this.Clientes = new HashSet<Cliente>();
        }
        [Key]
        public int EmpresaId { get; set; }
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La fecha es obligatorio")]
        public DateTime FechaConstituida { get; set; }
        public virtual ICollection<Cliente>? Clientes { get; set; }
    }
}
