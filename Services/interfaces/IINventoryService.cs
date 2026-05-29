using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IInventoryService
{
    Task<List<Inventory>> GetAll();

    Task Add(Inventory inventory);

    Task Delete(int id);
}