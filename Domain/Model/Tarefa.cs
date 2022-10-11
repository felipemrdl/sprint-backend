using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    [Table("TB_TAREFA")]
    public class Tarefa
    {
        public Tarefa() {
            TarefaComentarios = new HashSet<TarefaComentario>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("TarefaStatusId")]
        public int TarefaStatusId { get; set; }
        [Column("SprintId")]
        public int SprintId { get; set; }
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Finalizada")]
        public bool Finalizada { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual TarefaStatus TarefaStatus { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual ICollection<TarefaComentario> TarefaComentarios { get; set; }
    }
}