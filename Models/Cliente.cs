using System.ComponentModel.DataAnnotations;

namespace AdministracionEmpresa.Models
{
    public partial class Cliente

    {
       
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "La empresa es obligatorio")]
        public int EmpresaId { get; set; }
        [Required(ErrorMessage ="El sexo es obligatorio")]
        public int SexoId { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La Cedula es obligatorio")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "La Fecha de nacimiento es obligatorio")]
        public DateTime FechaNacimiento { get; set; }
        public virtual Empresa? Empresa { get; set; }

    }
}
