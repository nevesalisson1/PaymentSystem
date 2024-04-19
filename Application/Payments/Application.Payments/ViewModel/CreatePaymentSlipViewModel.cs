using System.ComponentModel.DataAnnotations;

namespace Application.Payments.ViewModel;

public record CreatePaymentSlipViewModel
{
    [Required]
    public string PayerName { get; set; }
    [Required]
    public string PayerDocument { get; set; }
    [Required]
    public string BeneficiaryName { get; set; }
    [Required]
    public string BeneficiaryDocument { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0.01")]
    public decimal? Value { get; set; }
    [Required]
    public DateTime? DueDate { get; set; }
    public string Observation { get; set; }
    [Required]
    public int? BankId { get; set; }
};