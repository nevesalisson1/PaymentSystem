using System.ComponentModel.DataAnnotations;

namespace Domain.Payments.Models;

public class Bank
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string BankName { get; set; }
    [Required]
    public string BankCode { get; set; }
    [Required]
    public decimal InterestRate { get; set; }
}
