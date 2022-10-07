using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sprint_backend.Domain.Model;

namespace sprint_backend.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}

        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<TarefaComentario> TarefaComentario { get; set; }
        public DbSet<TarefaStatus> TarefaStatus { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioSprint> UsuarioSprint { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<UsuarioSprint>()
            .HasOne(o => o.Usuario)
            .WithMany(m => m.UsuarioSprint);

            builder.Entity<UsuarioSprint>()
            .HasOne(o => o.Sprint)
            .WithMany(m => m.UsuarioSprint);
            
        }
    }
}