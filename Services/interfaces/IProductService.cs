using Backend.Models;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task<Product?> GetById(int id);
    Task Add(Product product);
    Task Delete (int id);
    Task Update(int id, Product product);
}