using Domain.Payments.Models;
using Domain.Payments.Repository;
using Infrastructure.Domain.Payments.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Payments.Repository;

public class BankRepository : IBankRepository
{
    private readonly IPaymentsContext _context;

    public BankRepository(IPaymentsContext context)
    {
        _context = context;
    }

    public async Task<Bank?> GetBankAsync(int id)
    {
        return await _context.Banks.FindAsync(id);
    }

    public async Task<List<Bank>> GetBankListAsync()
    {
        return await _context.Banks.ToListAsync();
    }

    public async Task<int> CreateBankAsync(Bank bank)
    {
        _context.Banks.Add(bank);
        await _context.SaveChangesAsync();
        return bank.Id;
    }
}
