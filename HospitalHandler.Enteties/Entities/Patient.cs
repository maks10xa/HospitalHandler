using System.Drawing;

namespace HospitalHandler.Enteties.Entities
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Gender { get; set; } = "unknown";
        public DateTime BirthdDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
