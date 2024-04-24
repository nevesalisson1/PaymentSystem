using Application.Localidade.AutoMapper;
using Application.Payments.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankAppService _bankAppService;
    private readonly IPaymentSlipAppService _paymentSlipAppService;

    public BankController(IBankAppService bankAppService, IPaymentSlipAppService paymentSlipAppService)
    {
        _bankAppService = bankAppService;
        _paymentSlipAppService = paymentSlipAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBank([FromBody] CreateBankViewModel createBankViewModel)
    {
        var bankId = await _bankAppService.CreateBank(createBankViewModel);
        return CreatedAtAction(nameof(GetBank), new { id = bankId }, new { BankId = bankId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBank(int id)
    {
        var bank = await _bankAppService.GetBank(id);
        if (bank == null)
        {
            return NotFound();
        }
        return Ok(bank);
    }

    [HttpGet]
    public async Task<IActionResult> GetBankList()
    {
        var bank = await _bankAppService.GetBankList();
        if (bank == null || !bank.Any())
        {
            return NotFound();
        }
        return Ok(bank);
    }
}