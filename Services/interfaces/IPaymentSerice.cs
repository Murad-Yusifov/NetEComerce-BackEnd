using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IPaymentService
{
    Task<List<Payment>> GetAll();

    Task Add(Payment payment);

    Task Delete(int id);
}