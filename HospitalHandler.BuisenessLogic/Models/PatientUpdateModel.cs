using System.ComponentModel.DataAnnotations;

namespace HospitalHandler.BuisenessLogic.Models
{
    public class PatientUpdateModel
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid NameId { get; set; }
        [Required]
        public Gender Gender { get; set; } = Gender.unknown;
        [Required]
        public DateTime BirthdDate { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        [Required]
        public string Use { get; set; } = "official";
        [Required]
        public string Family { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
    }
}
