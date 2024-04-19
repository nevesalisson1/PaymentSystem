using Domain.Payments.Models;

namespace Domain.Payments.Repository;

public interface IBankRepository
{
    public Task<Bank?> GetBankAsync(int id);
    public Task<List<Bank>> GetBankListAsync();
    public Task<int> CreateBankAsync(Bank bank);
}