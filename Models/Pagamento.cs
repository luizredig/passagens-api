using System.ComponentModel.DataAnnotations;

public class Pagamento
{
    [Key]
    public int Id { get; set; }
    public string? Tipo { get; set; }
}