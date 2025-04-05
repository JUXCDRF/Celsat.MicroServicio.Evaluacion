using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsat.MicroServicio.Evaluacion.Application.Dtos;

public class CreateUpdateEmpleadosDtoRequest
{
    public int? Id { get; set; }
    public string Nombre { get; set; } = string.Empty!;
    public string Cargo { get; set; } = string.Empty!;
    public DateTime FechaIngreso { get; set; }
    public string Email { get; set; } = string.Empty!;
}
