using Xunit;
using Moq;
using Application.Payments.AppServices;
using Domain.Payments.Models;
using Domain.Payments.Repository;
using Application.Payments.ViewModel;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BankAppServiceTests
{
    private readonly Mock<IBankRepository> _bankRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly BankAppService _bankAppService;

    public BankAppServiceTests()
    {
        _bankRepositoryMock = new Mock<IBankRepository>();
        _mapperMock = new Mock<IMapper>();
        _bankAppService = new BankAppService(_bankRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateBank_ShouldReturnExpectedResult()
    {
        // Arrange
        var createBankViewModel = new CreateBankViewModel();
        var bank = new Bank();
        _mapperMock.Setup(m => m.Map<Bank>(createBankViewModel)).Returns(bank);
        _bankRepositoryMock.Setup(r => r.CreateBankAsync(bank)).ReturnsAsync(1);

        // Act
        var result = await _bankAppService.CreateBank(createBankViewModel);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetBank_ShouldReturnExpectedResult()
    {
        // Arrange
        var id = 1;
        var bank = new Bank();
        var bankViewModel = new BankViewModel();
        _bankRepositoryMock.Setup(r => r.GetBankAsync(id)).ReturnsAsync(bank);
        _mapperMock.Setup(m => m.Map<BankViewModel>(bank)).Returns(bankViewModel);

        // Act
        var result = await _bankAppService.GetBank(id);

        // Assert
        Assert.Equal(bankViewModel, result);
    }

    [Fact]
    public async Task GetBankList_ShouldReturnExpectedResult()
    {
        // Arrange
        var banks = new List<Bank>();
        var bankViewModels = new List<BankViewModel>();
        _bankRepositoryMock.Setup(r => r.GetBankListAsync()).ReturnsAsync(banks);
        _mapperMock.Setup(m => m.Map<List<BankViewModel>>(banks)).Returns(bankViewModels);

        // Act
        var result = await _bankAppService.GetBankList();

        // Assert
        Assert.Equal(bankViewModels, result);
    }
}