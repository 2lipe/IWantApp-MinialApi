namespace IWantApp.Domain.Products;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public bool HasActive { get; set; } = true;
}