using Celsat.MicroServicio.Evaluacion.Application.Dtos;
using Celsat.MicroServicio.Evaluacion.Application.Dtosl;
using Celsat.MicroServicio.Evaluacion.Domain.Entities;
using Celsat.MicroServicio.Evaluacion.Infraestructure.Db;
using Dapper;
using System.Data;

namespace Celsat.MicroServicio.Evaluacion.Application.Respositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DapperContext _context;

        public EmpleadoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUpdateEmpleadosAsync(CreateUpdateEmpleadosDtoRequest request)
        {
            var query = "CreatedEmpleado";
            var parametros = new DynamicParameters();
            parametros.Add("@Id", request.Id, DbType.Int32);
            parametros.Add("@Nombre", request.Nombre, DbType.String);
            parametros.Add("@Cargo", request.Cargo, DbType.String);
            parametros.Add("@FechaIngreso", request.FechaIngreso, DbType.Date);
            parametros.Add("@Email", request.Email, DbType.String);
            using var connection = _context.CreateConnection();
            var InsertoUpdate= await connection.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
            if (InsertoUpdate > 0)
            {

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Empleado>> ListarActivosAsync()
        {
            var query = "SP_ListarEmpleados";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Empleado>(query, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ListEmpleadosByYearDtoResponse>> ListEmpleadosByYearAsync(ListadoByYearDtoRequest request)
        {
            var query = "ListEmpleadoByYear";
            var parametros = new DynamicParameters();
            parametros.Add("@FechaIngreso", request.FechaIngreso, DbType.Date);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ListEmpleadosByYearDtoResponse>(query, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
