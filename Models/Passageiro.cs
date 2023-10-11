using System.ComponentModel.DataAnnotations;

public class Passageiro
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
}