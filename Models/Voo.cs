using System.ComponentModel.DataAnnotations;

public class Voo
{
    [Key]
    public int Id { get; set; }
    public string? Numero { get; set; }
    public Aviao? Aviao { get; set; }
    public int AviaoId { get; set; }
    public Aeroporto? OrigemAeroporto { get; set; }
    public int OrigemAeroportoId { get; set; }
    public Aeroporto? DestinoAeroporto { get; set; }
    public int DestinoAeroportoId { get; set; }
}