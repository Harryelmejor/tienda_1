namespace tienda_1.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Identification { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
