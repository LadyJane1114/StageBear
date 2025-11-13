using System.ComponentModel.DataAnnotations;

namespace StageBear.Models
{
    public class Purchase
    {
        //primarykey
        public int PurchaseID { get; set; }

        public int TicketsPurchased { get; set; }

        public string ClientFName { get; set; } = string.Empty;
        public string ClientLName { get; set; } = string.Empty;
        public string ClientFullName => $"{ClientFName} {ClientLName}";

        public string ClientStAddress { get; set; }= string.Empty;
        public string ClientCity { get; set; } = string.Empty;
        public string? ClientRegion { get; set; } = string.Empty;
        public string ClientCountry { get; set; } = string.Empty;
        public string ClientPostCode { get; set; } = string.Empty;

        public string FullAddress => $"{ClientStAddress} " +
                                        $"{ClientCity}, {ClientRegion} {ClientCountry}" +
                                        $"{ClientPostCode}";

        public string ClientEmail { get; set; } = string.Empty;
        public string? ClientPhone { get; set; } = string.Empty;

        [Required]
        [MaxLength(16, ErrorMessage = "Card number cannot exceed 16 characters.")]
        public string CardNum { get; set; } = string.Empty;
        [Required]
        [MaxLength(2, ErrorMessage = "Card number cannot exceed 2 characters.")]
        public string CardExpMon { get; set; } = string.Empty;
        [Required]
        [MaxLength(2, ErrorMessage = "Card number cannot exceed 2 characters.")]
        public string CardExpYear { get; set; } = string.Empty;
        public string CardExpiry => $"{CardExpMon} / {CardExpYear}";
        [Required]
        [MaxLength(3, ErrorMessage = "Card number cannot exceed 3 characters.")]
        public int CardSecCode { get; set; }

        //foreign key
        public int ShowID { get; set; }
        //navigation property
        public Show? Show { get; set; }
    }
}
