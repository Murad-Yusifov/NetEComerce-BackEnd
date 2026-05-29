using Backend.Models;

public interface IAddressService
{
    Task<List<Address>> GetAll();

    Task Add(Address address);
}