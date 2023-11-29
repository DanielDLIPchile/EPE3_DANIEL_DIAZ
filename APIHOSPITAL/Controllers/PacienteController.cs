using APIHOSPITAL.DAL;
using APIHOSPITAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly APIHOSPITALDbContext _context;

        // Constructor del controlador que recibe el contexto de la base de datos
        public PacienteController(APIHOSPITALDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var paciente = _context.Paciente.ToList();
                // Si no hay pacientes o la lista es nula, devuelve un error 404 (Not Found)
                if (paciente.Count == 0 || paciente == null)
                {
                    return NotFound("No hay pacientes disponibles");
                }
                // Devuelve una respuesta exitosa con la lista de pacientes
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var paciente = _context.Paciente.Find(id);
                // Si el paciente no existe, devuelve un error 404 (Not Found)
                if (paciente == null)
                {
                    return NotFound($"No se encontraron detalles con la ID proporcionada {id}");
                }
                // Devuelve una respuesta exitosa con los detalles del paciente
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Paciente model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que el paciente ha sido ingresado
                return Ok("Paciente ingresado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Paciente model)
        {
            // Verifica si el modelo o el id del paciente son inválidos
            if (model == null || model.idPaciente == 0)
            {
                if (model == null)
                {
                    return BadRequest("Los datos son inválidos");
                }
                else if (model.idPaciente == 0)
                {
                    return BadRequest($"El id {model.idPaciente} es inválido");
                }
            }
            try
            {
                // Busca al paciente por su id
                var paciente = _context.Paciente.Find(model.idPaciente);
                // Si el paciente no existe, devuelve un error 404 (Not Found)
                if (paciente == null)
                {
                    return NotFound($"El paciente con id {model.idPaciente} no existe");
                }
                // Actualiza los detalles del paciente con los datos proporcionados
                paciente.idPaciente = model.idPaciente;
                paciente.NombrePac = model.NombrePac;
                paciente.ApellidoPac = model.ApellidoPac;
                paciente.RunPac = model.RunPac;
                paciente.Nacionalidad = model.Nacionalidad;
                paciente.Visa = model.Visa;
                paciente.Genero = model.Genero;
                paciente.SintomasPac = model.SintomasPac;
                paciente.Medico_idMedico = model.Medico_idMedico;
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que los medicos han sido actualizados
                return Ok("Paciente actualizado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Busca al paciente por su id
                var paciente = _context.Paciente.Find(id);
                // Si el paciente no existe, devuelve un error 404 (Not Found)
                if (paciente == null)
                {
                    return NotFound($"El paciente con el id {id} no existe");
                }
                // Elimina al paciente de la base de datos
                _context.Paciente.Remove(paciente);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que el paciente ha sido borrado
                return Ok($"El paciente con id {id} ha sido eliminado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
