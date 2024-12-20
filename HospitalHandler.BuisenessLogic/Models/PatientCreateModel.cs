using System.ComponentModel.DataAnnotations;

namespace HospitalHandler.BuisenessLogic.Models
{
    public class PatientCreateModel
    {
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

    public enum Gender
    {
        male,
        female,
        other,
        unknown
    }
}
