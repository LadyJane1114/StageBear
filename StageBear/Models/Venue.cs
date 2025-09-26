namespace StageBear.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty ;
        public string PostCode { get; set; } = string.Empty;
        public string VenueNotes {  get; set; } = string.Empty;

        //Navigation property
        public List<Venue>? Venues { get; set; }
    }
}
