using System.ComponentModel.DataAnnotations;

namespace StageBear.Models
{
    public class Owner
    {
        [Display(Name = "ID")]
        public int OwnerId { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LName { get; set; } = string.Empty ;

        public string Pronouns { get; set; } = string.Empty ;

        [Display(Name = "Name")]
        public string FullName => $"{FName} {LName}";


        public string? Organization { get; set; }

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Notes")]
        public string? OwnerNotes {  get; set; }

        //Navigation property
        public List<Owner>? Owners { get; set; }
    }
}
