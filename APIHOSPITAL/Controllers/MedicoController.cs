using APIHOSPITAL.DAL;
using APIHOSPITAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly APIHOSPITALDbContext _context;

        // Constructor del controlador que recibe el contexto de la base de datos
        public MedicoController(APIHOSPITALDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var medico = _context.Medico.ToList();
                // Si no hay medicos o la lista es nula, devuelve un error 404 (Not Found)
                if (medico.Count == 0 || medico == null)
                {
                    return NotFound("No hay medicos disponibles");
                }
                // Devuelve una respuesta exitosa con la lista de medicos
                return Ok(medico);
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
                var medico = _context.Medico.Find(id);
                // Si el medico no existe, devuelve un error 404 (Not Found)
                if (medico == null)
                {
                    return NotFound($"No se encontraron detalles con la ID proporcionada {id}");
                }
                // Devuelve una respuesta exitosa con los detalles del medico
                return Ok(medico);
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Medico model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que el medico ha sido ingresado
                return Ok("Medico ingresado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Medico model)
        {
            // Verifica si el modelo o el id del medico son inválidos
            if (model == null || model.idMedico == 0)
            {
                if (model == null)
                {
                    return BadRequest("Los datos son inválidos");
                }
                else if (model.idMedico == 0)
                {
                    return BadRequest($"El id  {model.idMedico} es inválido");
                }
            }
            try
            {
                // Busca el medico por su id
                var medico = _context.Medico.Find(model.idMedico);
                // Si el medico no existe, devuelve un error 404 (Not Found)
                if (medico == null)
                {
                    return NotFound($"El medico con id {model.idMedico} no existe");
                }
                // Actualiza los detalles del medico con los datos proporcionados
                medico.idMedico = model.idMedico;
                medico.NombreMed = model.NombreMed;
                medico.ApellidoMed = model.ApellidoMed;
                medico.RunMed = model.RunMed;
                medico.Eunacom = model.Eunacom;
                medico.NacionalidadMed = model.NacionalidadMed;
                medico.Especialidad = model.Especialidad;
                medico.Horarios = model.Horarios;
                medico.TarifaHr = model.TarifaHr;
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que los medicos han sido actualizados
                return Ok("Medico actualizado");
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
                // Busca el medico por su id
                var medico = _context.Medico.Find(id);
                // Si el medico no existe, devuelve un error 404 (Not Found)
                if (medico == null)
                {
                    return NotFound($"El medico con el id {id} no existe");
                }
                // Elimina el medico de la base de datos
                _context.Medico.Remove(medico);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que el medico ha sido borrado
                return Ok($"El medico con id {id} ha sido eliminado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }
    }

}
