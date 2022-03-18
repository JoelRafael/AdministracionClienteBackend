using System.ComponentModel.DataAnnotations;

namespace AdministracionEmpresa.Models
{
    public partial class Sexo
    {
        [Key]
        public int SexoId { get; set; }
        public string Nombre { get; set; }
    }
}
