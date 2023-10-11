using System.ComponentModel.DataAnnotations;

public class Aviao
{
    [Key]
    public int Id { get; set; }
    public string? Modelo { get; set; }
    public CompanhiaAerea? CompanhiaAerea { get; set; }
    public int CompanhiaAereaId { get; set; }
}