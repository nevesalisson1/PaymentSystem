﻿using Application.Localidade.AutoMapper;
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

    [HttpPost]
    public async Task<IActionResult> CreatePaymentSlip([FromBody] CreatePaymentSlipViewModel createPaymentSlipViewModel)
    {
        var paymentSlipId = await _paymentSlipAppService.CreatePaymentSlip(createPaymentSlipViewModel);
        return CreatedAtAction(nameof(GetPaymentSlip), new { id = paymentSlipId }, new { PaymentSlipId = paymentSlipId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentSlip(int id)
    {
        var paymentSlipViewModel = await _paymentSlipAppService.GetPaymentSlip(id);
        if (paymentSlipViewModel == null)
        {
            return NotFound();
        }
        return Ok(paymentSlipViewModel);
    }
}