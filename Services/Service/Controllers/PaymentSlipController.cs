using Application.Localidade.AutoMapper;
using Application.Payments.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentSlipController : ControllerBase
{
    private readonly IBankAppService _bankAppService;
    private readonly IPaymentSlipAppService _paymentSlipAppService;
    
    public PaymentSlipController(IBankAppService bankAppService, IPaymentSlipAppService paymentSlipAppService) 
    {
        _bankAppService = bankAppService;
        _paymentSlipAppService = paymentSlipAppService;
    }
    
    [HttpPost(Name = "CreatePaymentSlip")]
    public async Task<IActionResult> CreatePaymentSlip([FromBody] CreatePaymentSlipViewModel createPaymentSlipViewModel)
    {
        var paymentSlipId = await _paymentSlipAppService.CreatePaymentSlip(createPaymentSlipViewModel);
        return CreatedAtRoute("GetPaymentSlip", new { id = paymentSlipId }, new { PaymentSlipId = paymentSlipId });
    }
    
    [HttpGet("{id}", Name = "GetPaymentSlip")]
    public async Task<IActionResult> GetPaymentSlip(int id)
    {
        var paymentSlipViewModel = await _paymentSlipAppService.GetPaymentSlip(id);
        
        return Ok(paymentSlipViewModel);
    }
}