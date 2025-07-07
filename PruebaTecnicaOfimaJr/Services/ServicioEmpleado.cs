using System.Text.Json;
using PruebaTecnicaOfimaJr.Models;
namespace PruebaTecnicaOfimaJr.Services

{
    public class ServicioEmpleado
    {
        private readonly string _rutaArchivo = "App_Data\\Empleados.json";
        public List<Empleado> ObtenerEmpleados(){
            if (!File.Exists(_rutaArchivo)) {
                return new List<Empleado>();
            }
            var json = File.ReadAllText(_rutaArchivo);
            return JsonSerializer.Deserialize<List<Empleado>>(json) ?? new List<Empleado>();
        }

        public void GuardarEmpleados(List<Empleado> empleados){
            var json = JsonSerializer.Serialize(empleados, new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText(_rutaArchivo, json);
        }

        public void AgregarEmpleados(Empleado nuevo){
            var empleados = ObtenerEmpleados();
            nuevo.Id = empleados.Any() ? empleados.Max(c => c.Id) + 1: 1;
            empleados.Add(nuevo);
            GuardarEmpleados(empleados);
        }

        public bool EliminarEmpleado(int id) { 
            var empleados = ObtenerEmpleados();
            var empleado  = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null) 
                return false;
            
            empleados.Remove(empleado);
            GuardarEmpleados(empleados);
            return true;
        }

        public bool ActualizarEmpleado(int id, Empleado actualizado) { 
            var empleados = ObtenerEmpleados();
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null) return false;
            empleado.Nombre = actualizado.Nombre;
            empleado.Correo = actualizado.Correo;
            empleado.Departamento = actualizado.Departamento;
            empleado.Telefono = actualizado.Telefono;
            empleado.FechaIngreso= actualizado.FechaIngreso;
            empleado.Activo= actualizado.Activo;
            GuardarEmpleados(empleados);
            return true;
        }

        public Empleado BusquedaEmpleado(int id) { 
            var empleados = ObtenerEmpleados();
            var empleado = empleados.FirstOrDefault(e=>e.Id == id);
            if (empleado == null) return null;
            return empleado;

        }



    }
}
