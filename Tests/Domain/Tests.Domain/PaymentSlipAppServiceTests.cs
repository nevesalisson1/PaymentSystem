using Xunit;
using Moq;
using Application.Payments.AppServices;
using Domain.Payments.Models;
using Domain.Payments.Repository;
using Domain.Payments.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Application.Payments.ViewModel;

public class PaymentSlipAppServiceTests
{
    private Mock<IPaymentSlipRepository> _paymentSlipRepositoryMock;
    private Mock<IPaymentSlipService> _paymentSlipServiceMock;
    private Mock<IMapper> _mapperMock;
    private PaymentSlipAppService _paymentSlipAppService;

    public PaymentSlipAppServiceTests()
    {
        _paymentSlipRepositoryMock = new Mock<IPaymentSlipRepository>();
        _paymentSlipServiceMock = new Mock<IPaymentSlipService>();
        _mapperMock = new Mock<IMapper>();
        _paymentSlipAppService = new PaymentSlipAppService(_paymentSlipRepositoryMock.Object, _mapperMock.Object, _paymentSlipServiceMock.Object);
    }

    [Fact]
    public async Task CreatePaymentSlip_CallsRepositoryAndReturnsId()
    {
        // Arrange
        var createPaymentSlipDto = new CreatePaymentSlipViewModel();
        var paymentSlip = new PaymentSlip();
        _mapperMock.Setup(m => m.Map<PaymentSlip>(createPaymentSlipDto)).Returns(paymentSlip);
        _paymentSlipRepositoryMock.Setup(r => r.CreatePaymentSlipAsync(paymentSlip)).ReturnsAsync(1);

        // Act
        var result = await _paymentSlipAppService.CreatePaymentSlip(createPaymentSlipDto);

        // Assert
        Assert.Equal(1, result);
        _paymentSlipRepositoryMock.Verify(r => r.CreatePaymentSlipAsync(paymentSlip), Times.Once);
    }

    [Fact]
    public async Task GetPaymentSlip_CallsRepositoryAndReturnsPaymentSlipViewModel()
    {
        // Arrange
        var paymentSlip = new PaymentSlip();
        var paymentSlipViewModel = new PaymentSlipViewModel();
        _paymentSlipRepositoryMock.Setup(r => r.GetPaymentSlipAsync(It.IsAny<int>())).ReturnsAsync(paymentSlip);
        _mapperMock.Setup(m => m.Map<PaymentSlipViewModel>(paymentSlip)).Returns(paymentSlipViewModel);

        // Act
        var result = await _paymentSlipAppService.GetPaymentSlip(1);

        // Assert
        Assert.Equal(paymentSlipViewModel, result);
        _paymentSlipRepositoryMock.Verify(r => r.GetPaymentSlipAsync(It.IsAny<int>()), Times.Once);
    }
}