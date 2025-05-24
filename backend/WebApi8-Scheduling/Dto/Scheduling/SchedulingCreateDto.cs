using System.Text.Json.Serialization;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Dto.Scheduling
{
    public class SchedulingCreateDto
    {
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public int ServicoId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
