using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    public class TarefaComentario
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataComentario { get; set; }
        public int TarefaId { get; set; }

        public virtual Tarefa Tarefa { get; set; }
    }
}