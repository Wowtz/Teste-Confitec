using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CadastroContext : DbContext
{
    public CadastroContext(DbContextOptions<CadastroContext> options): base(options)
    {

    }

    public DbSet<CadastroPessoa> CadastroPessoa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(StringConnection());
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CadastroPessoa>().ToTable("CadastroDePessoas").HasKey(t => t.Id);

        base.OnModelCreating(builder);
    }

    public string StringConnection()
    {
        string strConnection = "Server=WALT; Database=TesteConfitec; Trusted_Connection=True;";
        return strConnection;
    }
}
