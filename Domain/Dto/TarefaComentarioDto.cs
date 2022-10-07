using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Dto
{
    public class TarefaComentarioDto
    {
        public int TarefaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
    }
}