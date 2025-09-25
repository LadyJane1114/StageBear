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
        public string Location { get; set; } = string.Empty;
        public string Owner {  get; set; } = string.Empty;
        public DateTime DateRecorded { get; set; }
        public string Image { get; set; } = string.Empty;


        //Foreign Key
        public int CategoryID { get; set; }
        // Navigation property
        public Category? Category  { get; set; }
    }
}
