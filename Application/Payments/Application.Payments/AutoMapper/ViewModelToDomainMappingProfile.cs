using Application.Payments.ViewModel;
using AutoMapper;
using Domain.Payments.Models;

namespace Application.Payments.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CreateBankViewModel, Bank>();

        CreateMap<CreatePaymentSlipViewModel, PaymentSlip>();
        CreateMap<PaymentSlipViewModel, PaymentSlip>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank)); // Adicione esta linha para mapear a propriedade Bank
    }
}
