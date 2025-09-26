using System.ComponentModel;

namespace StageBear.Models
{
    public class Show //I'd like to add images at some point.
    {
        //primary key
        public int ShowID { get; set; }


        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime Scheduled { get; set; }
        public DateTime DateRecorded { get; set; }
        public string Image { get; set; } = string.Empty;


        //Foreign Key for Category
        public int CategoryID { get; set; }
        // Navigation property
        public Category? Category  { get; set; }

        // Foreign key for Venue
        public int VenueID { get; set; }
        //Navigation property
        public Venue? Venue { get; set; }

        //Foreign key for Owner
        public int OwnerID { get; set; }
        //Navigation property
        public Owner? Owner { get; set; }
    }
}
