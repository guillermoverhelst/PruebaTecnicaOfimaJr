using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaOfimaJr.Services;
using PruebaTecnicaOfimaJr.Models;
namespace PruebaTecnicaOfimaJr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ServicioEmpleado _servicioEmpleado;

        public EmpleadoController() {
            _servicioEmpleado = new ServicioEmpleado();
        }

        [HttpGet]
        public IActionResult Get() {
            var empleados = _servicioEmpleado.ObtenerEmpleados();
            return Ok(empleados);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Empleado empleado) {
            _servicioEmpleado.AgregarEmpleados(empleado);
            return CreatedAtAction(nameof(Get), empleado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool eliminado = _servicioEmpleado.EliminarEmpleado(id);
            Console.WriteLine(eliminado);
            if (!eliminado) 
                return NotFound(new { mensaje = "Empleado No Encontrado" });

             return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empleado empleado){
            bool actualizado = _servicioEmpleado.ActualizarEmpleado(id, empleado);

            if (!actualizado) return NotFound(new { mensaje = "Empleado No Encontrado"});
            
            return Ok(empleado);
        }
    }
}
