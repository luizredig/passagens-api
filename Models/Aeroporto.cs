using System.ComponentModel.DataAnnotations;

public class Aeroporto
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cidade { get; set; }
}