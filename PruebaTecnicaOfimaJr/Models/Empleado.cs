using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaOfimaJr.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Correo es obligatorio")]
        public string Correo { get; set; }
        public string Cargo {  get; set; }
        public string Departamento {  get; set; }
        public string Telefono { get; set; }
        public string FechaIngreso { get; set; }
        public bool Activo {  get; set; }


    }
}
