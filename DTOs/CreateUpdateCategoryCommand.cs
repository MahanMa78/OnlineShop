namespace OnlineShop.DTOs
{
    public class CreateUpdateCategoryCommand
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
    }
}
