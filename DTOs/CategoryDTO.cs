namespace OnlineShop.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}
