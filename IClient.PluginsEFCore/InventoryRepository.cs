using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IClient.PluginsEFCore;

public class InventoryRepository : IInventoryRepository
{
    private readonly IClientContext db;

    public InventoryRepository(IClientContext db)
    {
        this.db = db;
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
    {
        return await this.db.Inventories.Where(x => x.Inventoryname.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        //return await this.db.Inventories.Where(x => x.Inventoryname
        //  .Contains(name,StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(name))
        //.ToListAsync();
    }
    

    public async Task<Inventory?> GetInventoryByIdAsync(int InventoryId)
    {
        return await this.db.Inventories.FindAsync(InventoryId);
    }

    public async Task AddInventoryAsync(Inventory inventory)
    {
        if (db.Inventories.Any(x =>
                x.Inventoryname.Equals(inventory.Inventoryname.ToLower() == inventory.Inventoryname.ToLower())))
        {
            return;
        }

        this.db.Inventories.Add(inventory);
        await this.db.SaveChangesAsync();
    }

    public async  Task UpdateInventoryAsync(Inventory inventory)
    {
        if(db.Inventories.Any(x=>x.InventoryId != inventory.InventoryId &&
                                 x.Inventoryname.ToLower() == inventory.Inventoryname.ToLower())) return;
        
        //if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId && 
          //                          x.Inventoryname.Equals(inventory.Inventoryname,
            //                            StringComparison.OrdinalIgnoreCase)))
       // {
         //   return;
        //}
        
        

        var inv = await this.db.Inventories.FindAsync(inventory.InventoryId);
        if (inv != null)
        {
            inv.Inventoryname = inventory.Inventoryname;
            inv.Price = inventory.Price;
            inv.Quantity = inventory.Quantity;

            await db.SaveChangesAsync();
        }
    }
}