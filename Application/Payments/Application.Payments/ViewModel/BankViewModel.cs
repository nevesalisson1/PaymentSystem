using System.ComponentModel.DataAnnotations;

namespace Application.Payments.ViewModel;

public record BankViewModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string BankName { get; set; }
    [Required]
    public string BankCode { get; set; }
    [Required]
    public decimal InterestRate { get; set; }
};