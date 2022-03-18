using System.ComponentModel.DataAnnotations;

namespace AdministracionEmpresa.Models
{
    public partial class Direccion
    {
        [Key]
        public int? DireccioneId { get; set; }
        [Required(ErrorMessage = "El id del cliente es obligatorio")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "La direccion  es obligatorio")]
        public string Nombre { get; set; }

    }
    public partial class Direcciones
    {
        public List<Direccion> ListaDirecciones { get; set; }
    }
}
