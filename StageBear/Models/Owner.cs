namespace StageBear.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty ;
        public string FullName => $"{FName} {LName}";
        public string Organization { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string OwnerNotes {  get; set; } = string.Empty;

        //Navigation property
        public List<Owner>? Owners { get; set; }
    }
}
