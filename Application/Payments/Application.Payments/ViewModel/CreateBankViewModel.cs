using System.ComponentModel.DataAnnotations;

namespace Application.Payments.ViewModel;

public record CreateBankViewModel
{
    [Required]
    public string BankName { get; set; }
    [Required]
    public string BankCode { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "InterestRate must be greater or equal than 0.01")]
    public decimal? InterestRate { get; set; }
};