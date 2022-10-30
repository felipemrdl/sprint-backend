using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    [Table("TB_SPRINT")]
    public class Sprint
    {
        public Sprint() {
            Tarefas = new HashSet<Tarefa>();
            UsuarioSprint = new HashSet<UsuarioSprint>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome"), MaxLength(50)]
        public string Nome { get; set; }
        [Column("PorcentagemConclusao")]
        public decimal PorcentagemConclusao { get; set; }
        [Column("DataInicio")]
        public DateTime? DataInicio { get; set; }
        [Column("DataFim")]
        public DateTime? DataFim { get; set; }

        public virtual ICollection<UsuarioSprint> UsuarioSprint { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}