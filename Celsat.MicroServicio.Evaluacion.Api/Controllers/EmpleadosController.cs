using Celsat.MicroServicio.Evaluacion.Application.Dtos;
using Celsat.MicroServicio.Evaluacion.Application.Respositories;
using Microsoft.AspNetCore.Mvc;


namespace Celsat.MicroServicio.Evaluacion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadosController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivos()
        {
            var empleados = await _empleadoRepository.ListarActivosAsync();
            return Ok(empleados);
        }
        [HttpGet("ListarEmpleadosByYear")]
        public async Task<IActionResult> GetEmpleadosByYear([FromQuery] ListadoByYearDtoRequest request)
        {
            var listado = await _empleadoRepository.ListEmpleadosByYearAsync(request);
            return Ok(listado);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdateEmpleados([FromBody] CreateUpdateEmpleadosDtoRequest request)
        {
            var result = await _empleadoRepository.CreateUpdateEmpleadosAsync(request);
            if (result)
            {
                return Ok(new { message = "Empleado creado o actualizado correctamente." });
            }
            return BadRequest(new { message = "Error al crear o actualizar el empleado." });
        }
    }
}
