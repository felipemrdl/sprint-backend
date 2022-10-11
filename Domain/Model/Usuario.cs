using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Model
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome"), MaxLength(50)]
        public string Nome { get; set; }
        [Column("Login"), MaxLength(50)]
        public string Login { get; set; }
        [Column("Senha"), MaxLength(50)]
        public string Senha { get; set; }
        [Column("Email"), MaxLength(100)]
        public string Email { get; set; }
        [Column("Tentativas")]
        public int Tentativas { get; set; }
        [Column("Ativo")]
        public bool Ativo { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        public virtual ICollection<UsuarioSprint> UsuarioSprint { get; set; }
    }
}