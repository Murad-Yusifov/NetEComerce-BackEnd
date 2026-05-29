using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IProductImageService
{
    Task<List<ProductImage>> GetAll();

    Task Add(ProductImage image);

    Task Delete(int id);
}