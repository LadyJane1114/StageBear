using System.ComponentModel.DataAnnotations;

namespace StageBear.Models
{
    public class Purchase
    {
        //primarykey
        [Display(Name = "Purchase ID")]
        public int PurchaseID { get; set; }


        [Display(Name = "Tickets Purchased")]
        public int TicketsPurchased { get; set; }

        [Display(Name = "Date of Transaction")]
        public DateTime DatePurchased { get; set; }


        [Display(Name = "Client First Name")]
        public string ClientFName { get; set; } = string.Empty;

        [Display(Name = "Client Surname")]
        public string ClientLName { get; set; } = string.Empty;

        [Display(Name = "Client Name")]
        public string ClientFullName => $"{ClientFName} {ClientLName}";


        [Display(Name = "Billing Street Address")]
        public string ClientStAddress { get; set; }= string.Empty;
        [Display(Name = "Billing City")]
        public string ClientCity { get; set; } = string.Empty;
        [Display(Name = "Billing Region")]
        public string? ClientRegion { get; set; } = string.Empty;
        [Display(Name = "Billing Country")]
        public string ClientCountry { get; set; } = string.Empty;
        [Display(Name = "Billing Post Code")]
        public string ClientPostCode { get; set; } = string.Empty;

        [Display(Name = "Billing Address")]
        public string FullAddress => $"{ClientStAddress} " +
                                        $"{ClientCity}, {ClientRegion} {ClientCountry}" +
                                        $"{ClientPostCode}";


        [Display(Name = "Client Email Address")]
        public string ClientEmail { get; set; } = string.Empty;
        [Display(Name = "Client Phone Number")]
        public string? ClientPhone { get; set; } = string.Empty;


        [Required]
        [MaxLength(16, ErrorMessage = "Card number cannot exceed 16 characters.")]
        [Display(Name = "Card Number")]
        public string CardNum { get; set; } = string.Empty;

        [Required]
        [MaxLength(2, ErrorMessage = "Card number cannot exceed 2 characters.")]
        [Display(Name = "Expiration Month")]
        public string CardExpMon { get; set; } = string.Empty;

        [Required]
        [MaxLength(2, ErrorMessage = "Card number cannot exceed 2 characters.")]
        [Display(Name = "Expiration Year")]
        public string CardExpYear { get; set; } = string.Empty;

        [Display(Name = "Expiration Date")]
        public string CardExpiry => $"{CardExpMon} / {CardExpYear}";
        [Required]
        [MaxLength(3, ErrorMessage = "Card number cannot exceed 3 characters.")]
        [Display(Name = "Security Code")]
        public int CardSecCode { get; set; }

        //foreign key
        public int ShowID { get; set; }
        //navigation property
        public Show? Show { get; set; }
    }
}
