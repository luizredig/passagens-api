using System.ComponentModel.DataAnnotations;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public Aeroporto? Aeroporto { get; set; }
    public int AeroportoId { get; set; }
}