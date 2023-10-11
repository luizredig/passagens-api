using Microsoft.EntityFrameworkCore;
public class APIDbContext : DbContext
{
    public DbSet<Aeroporto> Aeroportos { get; set; }
    public DbSet<Aviao> Avioes { get; set; }
    public DbSet<Bagagem> Bagagens { get; set; }
    public DbSet<CompanhiaAerea> CompanhiasAereas { get; set; }
    public DbSet<Passageiro> Passageiros { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Passagem> Passagens { get; set; }
    public DbSet<Portao> Portoes { get; set; }
    public DbSet<Voo> Voos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=passagem.db;Cache=Shared");
    }
}