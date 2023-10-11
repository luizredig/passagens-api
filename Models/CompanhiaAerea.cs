using System.ComponentModel.DataAnnotations;

public class CompanhiaAerea
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Pais { get; set; }
}