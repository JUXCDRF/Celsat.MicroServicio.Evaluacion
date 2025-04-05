using Celsat.MicroServicio.Evaluacion.Application.Dtos;
using Celsat.MicroServicio.Evaluacion.Application.Dtosl;
using Celsat.MicroServicio.Evaluacion.Domain.Entities;

namespace Celsat.MicroServicio.Evaluacion.Application.Respositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> ListarActivosAsync();
        Task<IEnumerable<ListEmpleadosByYearDtoResponse>> ListEmpleadosByYearAsync(ListadoByYearDtoRequest request);
        Task<bool> CreateUpdateEmpleadosAsync(CreateUpdateEmpleadosDtoRequest request);
    }
}
