using DataAccess.Models;

namespace DataAccess.Services;

public interface IInventoryService
{
    Task<List<Item>> GetItems();
}