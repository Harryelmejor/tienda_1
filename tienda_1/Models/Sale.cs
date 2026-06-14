namespace tienda_1.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int? ClientId { get; set; }
    public decimal Total { get; set; }

    public Client? Client { get; set; }
    public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();
}
