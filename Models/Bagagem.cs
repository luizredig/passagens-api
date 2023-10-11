using System.ComponentModel.DataAnnotations;

public class Bagagem
{
    [Key]
    public int Id { get; set; }
    public decimal Peso { get; set; }
    public Passageiro? Passageiro { get; set; }
    public int PassageiroId { get; set; }
}