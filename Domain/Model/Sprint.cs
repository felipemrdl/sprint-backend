using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    public class Sprint
    {
        public Sprint() {
            Tarefas = new HashSet<Tarefa>();
            UsuarioSprint = new HashSet<UsuarioSprint>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PorcentagemConclusao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<UsuarioSprint> UsuarioSprint { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}