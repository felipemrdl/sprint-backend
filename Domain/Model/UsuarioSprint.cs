using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    public class UsuarioSprint
    {
        public int Id { get; set; }
        public bool Finalizada { get; set; }
        public int SprintId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}