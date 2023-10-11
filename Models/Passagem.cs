using System.ComponentModel.DataAnnotations;

public class Passagem
{
    [Key]
    public int Id { get; set; }
    public string? Classe { get; set; }
    public decimal Preco { get; set; }
    public Pagamento? Pagamento { get; set; }
    public int PagamentoId { get; set; }
    public Portao? Portao { get; set; }
    public int PortaoId { get; set; }
    public Voo? Voo { get; set; }
    public int VooId { get; set; }
    public Passageiro? Passageiro { get; set; }
    public int PassageiroId { get; set; }
}