using Application.Localidade.AutoMapper;
using Application.Payments.ViewModel;
using AutoMapper;
using Domain.Payments.Models;
using Domain.Payments.Repository;

namespace Application.Payments.AppServices;

public class PaymentSlipAppService : IPaymentSlipAppService
{
    private readonly IPaymentSlipRepository _paymentSlipRepository;
    private readonly IMapper _mapper;

    public PaymentSlipAppService(IPaymentSlipRepository paymentSlipRepository, IMapper mapper)
    {
        _paymentSlipRepository = paymentSlipRepository;
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
            int monthsPastDue = CalculateMonthsPastDue(paymentSlip.DueDate);
            decimal totalInterest = CalculateTotalInterest(paymentSlip.Value, paymentSlip.Bank.InterestRate, monthsPastDue);

            paymentSlip.Value += totalInterest;
        }
        return _mapper.Map<PaymentSlipViewModel>(paymentSlip);
    }

    private int CalculateMonthsPastDue(DateTime dueDate)
    {
        return ((DateTime.Now.Year - dueDate.Year) * 12) + DateTime.Now.Month - dueDate.Month;
    }

    private decimal CalculateTotalInterest(decimal value, decimal interestRate, int monthsPastDue)
    {
        return value * interestRate * monthsPastDue;
    }
}