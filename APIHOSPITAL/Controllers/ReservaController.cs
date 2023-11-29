using APIHOSPITAL.DAL;
using APIHOSPITAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly APIHOSPITALDbContext _context;

        // Constructor del controlador que recibe el contexto de la base de datos
        public ReservaController(APIHOSPITALDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var reserva = _context.Reserva.ToList();
                // Si no hay reservas o la lista es nula, devuelve un error 404 (Not Found)
                if (reserva.Count == 0 || reserva == null)
                {
                    return NotFound("No hay reservas disponibles");
                }
                // Devuelve una respuesta exitosa con la lista de reservas
                return Ok(reserva);
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
                var reserva = _context.Reserva.Find(id);
                // Si la reserva no existe, devuelve un error 404 (Not Found)
                if (reserva == null)
                {
                    return NotFound($"No se encontraron detalles con la ID proporcionada {id}");
                }
                // Devuelve una respuesta exitosa con los detalles del paciente
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Reserva model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que la reserva ha sido ingresado
                return Ok("Reserva ingresada");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Reserva model)
        {
            // Verifica si el modelo o el id de la reserva son inválidos
            if (model == null || model.idReserva == 0)
            {
                if (model == null)
                {
                    return BadRequest("Los datos son inválidos");
                }
                else if (model.idReserva == 0)
                {
                    return BadRequest($"El id {model.idReserva} es inválido");
                }
            }
            try
            {
                // Busca la reserva por su id
                var reserva= _context.Reserva.Find(model.idReserva);
                // Si la reserva no existe, devuelve un error 404 (Not Found)
                if (reserva == null)
                {
                    return NotFound($"La reserva con id {model.idReserva} no existe");
                }
                // Actualiza los detalles de la reserva con los datos proporcionados
                reserva.idReserva= model.idReserva;
                reserva.Especialidad = model.Especialidad;
                reserva.DiaReserva = model.DiaReserva;
                reserva.Paciente_idPaciente = model.Paciente_idPaciente;
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que las reservas han sido actualizados
                return Ok("Reserva actualizada");
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
                // Busca a la reserva por su id
                var reserva = _context.Reserva.Find(id);
                // Si la reserva no existe, devuelve un error 404 (Not Found)
                if (reserva == null)
                {
                    return NotFound($"La reserva con el id {id} no existe");
                }
                // Elimina la reserva de la base de datos
                _context.Reserva.Remove(reserva);
                _context.SaveChanges();
                // Devuelve una respuesta exitosa indicando que la reserva ha sido borrado
                return Ok($"La reserva con id {id} ha sido eliminado");
            }
            catch (Exception ex)
            {
                // Devuelve un error 400 (Bad Request) junto con el mensaje de la excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
