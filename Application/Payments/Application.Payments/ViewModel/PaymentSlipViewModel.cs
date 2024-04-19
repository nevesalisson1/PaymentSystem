using System.ComponentModel.DataAnnotations;

namespace Application.Payments.ViewModel;

public record PaymentSlipViewModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string PayerName { get; set; }
    [Required]
    public string PayerDocument { get; set; }
    [Required]
    public string BeneficiaryName { get; set; }
    [Required]
    public string BeneficiaryDocument { get; set; }
    [Required]
    public decimal Value { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    public string Observation { get; set; }
    [Required]
    public int BankId { get; set; }
    public BankViewModel Bank { get; set; }
};