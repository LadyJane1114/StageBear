using System.ComponentModel;

namespace StageBear.Models
{
    public class Event //I'd like to add images at some point.
    {
        public int EventID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime Scheduled { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Owner {  get; set; } = string.Empty;
        public DateTime DateRecorded { get; set; }

        public int CategoryID { get; set; }
        public Category? Category  { get; set; }
    }
}
