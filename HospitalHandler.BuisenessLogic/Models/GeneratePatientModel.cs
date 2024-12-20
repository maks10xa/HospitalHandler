namespace HospitalHandler.BuisenessLogic.Models
{
    public class GeneratePatientModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
