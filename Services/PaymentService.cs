using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;

    public PaymentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAll()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task Add(Payment payment)
    {
        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return;

        _context.Payments.Remove(payment);

        await _context.SaveChangesAsync();
    }
}