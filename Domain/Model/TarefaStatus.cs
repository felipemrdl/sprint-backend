using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    [Table("TB_TAREFA_STATUS")]
    public class TarefaStatus
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
    }
}