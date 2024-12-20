using System.Diagnostics;
using System.Drawing;

namespace HospitalHandler.Enteties.Entities
{
    public class Name
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public string Use { get; set; } = "official";
        public string Family { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
