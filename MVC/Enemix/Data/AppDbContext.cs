using Enemix.Models;
using Microsoft.EntityFrameworkCore;

namespace Enemix.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<MaterialEstudo> MateriaisEstudo { get; set; }
    public DbSet<Questao> Questoes { get; set; }
    public DbSet<TopicoEstudo> TopicosEstudo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurando o relacionamento CASCADE para deletar questões ao deletar o material
        modelBuilder.Entity<Questao>()
            .HasOne(q => q.MaterialEstudo)
            .WithMany(m => m.Questoes)
            .HasForeignKey(q => q.MaterialEstudoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}