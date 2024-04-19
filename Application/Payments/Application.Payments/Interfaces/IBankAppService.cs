using Application.Payments.ViewModel;

namespace Application.Localidade.AutoMapper;

public interface IBankAppService
{
    Task<int> CreateBank(CreateBankViewModel createBankViewModel);
    Task<BankViewModel> GetBank(int id);
    Task<List<BankViewModel>> GetBankList();
}