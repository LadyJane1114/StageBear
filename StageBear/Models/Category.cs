namespace StageBear.Models
{
    public class Category //Need to figure out category tags.
    {
        //primary key
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; } = string.Empty;

        //Navigation property
        public List<Category>? Categories { get; set; }
    }
}
