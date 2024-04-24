using Application.Localidade.AutoMapper;
using Application.Payments.ViewModel;
using AutoMapper;
using Domain.Payments.Models;
using Domain.Payments.Repository;
using Domain.Payments.Services.Interfaces;

namespace Application.Payments.AppServices;

public class PaymentSlipAppService : IPaymentSlipAppService
{
    private readonly IPaymentSlipRepository _paymentSlipRepository;
    private readonly IPaymentSlipService _paymentSlipService;
    private readonly IMapper _mapper;

    public PaymentSlipAppService(IPaymentSlipRepository paymentSlipRepository, IMapper mapper, IPaymentSlipService paymentSlipService)
    {
        _paymentSlipRepository = paymentSlipRepository;
        _paymentSlipService = paymentSlipService;
        _mapper = mapper;
    }

    public async Task<int> CreatePaymentSlip(CreatePaymentSlipViewModel createPaymentSlipDto)
    {
        var paymentSlip = _mapper.Map<PaymentSlip>(createPaymentSlipDto);
        return await _paymentSlipRepository.CreatePaymentSlipAsync(paymentSlip);
    }

    public async Task<PaymentSlipViewModel> GetPaymentSlip(int id)
    {
        var paymentSlip = await _paymentSlipRepository.GetPaymentSlipAsync(id);
        if (paymentSlip?.DueDate.Date < DateTime.Now.Date)
        {
            paymentSlip.Value = _paymentSlipService.CalculatePaymentSlip(paymentSlip);
        }
        return _mapper.Map<PaymentSlipViewModel>(paymentSlip);
    }
}