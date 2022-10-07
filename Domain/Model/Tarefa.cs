using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    public class Tarefa
    {
        public Tarefa() {
            TarefaComentarios = new HashSet<TarefaComentario>();
        }


        public int Id { get; set; }
        public int TarefaStatusId { get; set; }
        public int SprintId { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Finalizada { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual TarefaStatus TarefaStatus { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual ICollection<TarefaComentario> TarefaComentarios { get; set; }
    }
}