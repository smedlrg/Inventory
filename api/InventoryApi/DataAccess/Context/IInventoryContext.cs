using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;
public interface IInventoryContext
{
    DbSet<Item> Item { get; set; }
}