using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ObservacaoModel> Observacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new ObservacaoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
