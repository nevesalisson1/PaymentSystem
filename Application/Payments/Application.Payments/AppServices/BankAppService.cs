using Application.Localidade.AutoMapper;
using Application.Payments.ViewModel;
using AutoMapper;
using Domain.Payments.Models;
using Domain.Payments.Repository;

namespace Application.Payments.AppServices;

public class BankAppService : IBankAppService
{
    private readonly IBankRepository _bankRepository;
    private readonly IMapper _mapper;
    
    public BankAppService(IBankRepository bankRepository, IMapper mapper)
    {
        _bankRepository = bankRepository;
        _mapper = mapper;
    }
    
    public async Task<int> CreateBank(CreateBankViewModel createBankViewModel)
    {
        var bank = _mapper.Map<Bank>(createBankViewModel);
        return await _bankRepository.CreateBankAsync(bank);
    }

    public async Task<BankViewModel> GetBank(int id)
    { 
        var bank = await _bankRepository.GetBankAsync(id);
       return _mapper.Map<BankViewModel>(bank);
    }

    public async Task<List<BankViewModel>> GetBankList()
    {
        var bank = await _bankRepository.GetBankListAsync();
        return _mapper.Map<List<BankViewModel>>(bank);
    }
}