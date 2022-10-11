using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    [Table("TB_TAREFA_COMENTARIO")]
    public class TarefaComentario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("DataComentario")]
        public DateTime DataComentario { get; set; }

        [Column("TarefaId")]
        public int TarefaId { get; set; }

        public virtual Tarefa Tarefa { get; set; }
    }
}