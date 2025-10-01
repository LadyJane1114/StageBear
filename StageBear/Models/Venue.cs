using System.ComponentModel.DataAnnotations;

namespace StageBear.Models
{
    public class Venue
    {
        [Display(Name = "ID")]
        public int VenueId { get; set; }

        [Display(Name = "Venue")]
        public string VenueName { get; set; } = string.Empty;

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; } = string.Empty;

        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Region")]
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        [Display(Name = "Post Code")]
        public string PostCode { get; set; } = string.Empty;

        [Display(Name = "Address")]
        public string FullAddress => $"{StreetAddress} " +
                                        $"{City}, {Region} " +
                                        $"{PostCode}";
        [Display(Name = "Notes")]
        public string VenueNotes {  get; set; } = string.Empty;

        //Navigation property
        public List<Venue>? Venues { get; set; }
    }
}
