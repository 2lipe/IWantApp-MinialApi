namespace IWantApp.Domain.Products;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public bool HasActive { get; set; } = true;
}