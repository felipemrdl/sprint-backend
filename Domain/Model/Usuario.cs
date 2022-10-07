using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Tentativas { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual ICollection<UsuarioSprint> UsuarioSprint { get; set; }
    }
}