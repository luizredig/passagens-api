using System.ComponentModel.DataAnnotations;

public class Portao
{
    [Key]
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public Aeroporto? Aeroporto { get; set; }
    public int AeroportoId { get; set; }
}