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
        public string ClientPhone { get; set; } = string.Empty;


        public int CardNum { get; set; }
        public int CardExpMon { get; set; }
        public int CardExpYear { get; set; }
        public string CardExpiry => $"{CardExpMon} / {CardExpYear}";
        public int CardSecCode { get; set; }

        //foreign key
        public int ShowID { get; set; }
        //navigation property
        public Show? Show { get; set; }
    }
}
