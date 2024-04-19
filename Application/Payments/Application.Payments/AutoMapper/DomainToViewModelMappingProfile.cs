using Application.Payments.ViewModel;
using AutoMapper;
using Domain.Payments.Models;

namespace Application.Payments.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Bank, BankViewModel>();
        CreateMap<PaymentSlip, PaymentSlipViewModel>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank));
        CreateMap<PaymentSlip, CreatePaymentSlipViewModel>();
    }
}

