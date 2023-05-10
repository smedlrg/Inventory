namespace DataAccess.Models;
/// <summary>
/// Defines an Item
/// </summary>
public class Item
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
