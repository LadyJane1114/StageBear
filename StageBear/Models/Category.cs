using System.ComponentModel.DataAnnotations;

namespace StageBear.Models
{
    public class Category 
    {
        [Display(Name = "Category ID")]
        //primary key
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryTitle { get; set; } = string.Empty;

        //Navigation property
        public List<Category>? Categories { get; set; }
    }
}
