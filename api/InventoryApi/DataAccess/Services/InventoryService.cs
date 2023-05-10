using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services;
/// <summary>
/// Service for connecting to dbcontext
/// </summary>
public class InventoryService : IInventoryService
{
    private readonly IInventoryContext _context;

    public InventoryService(IInventoryContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns List of Items
    /// </summary>
    /// <returns>Items</returns>
    public async Task<List<Item>> GetItems()
    {
        return await _context.Item.ToListAsync();
    }
}
