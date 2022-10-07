using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Dto
{
    public class TarefaDto
    {
        public TarefaDto() {
            Comentarios = new List<TarefaComentarioDto>();
        }
        public int TarefaStatusId { get; set; }
        public int SprintId { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<TarefaComentarioDto> Comentarios { get; set; }
    }
}