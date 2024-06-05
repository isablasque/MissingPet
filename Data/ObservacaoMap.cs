using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ObservacaoMap : IEntityTypeConfiguration<ObservacaoModel>
    {
        public void Configure(EntityTypeBuilder<ObservacaoModel> builder)
        {
            builder.HasKey(x => x.ObservacaoId);
            builder.Property(x=> x.ObservacaoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoLocal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
