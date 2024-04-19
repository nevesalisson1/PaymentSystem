using Application.Payments.ViewModel;

namespace Application.Localidade.AutoMapper;

public interface IPaymentSlipAppService
{
    Task<int> CreatePaymentSlip(CreatePaymentSlipViewModel createPaymentSlipDto);
    Task<PaymentSlipViewModel> GetPaymentSlip(int id);
}