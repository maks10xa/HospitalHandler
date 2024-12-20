using HospitalHandler.BuisenessLogic.Models;

List<GeneratePatientModel> patientsInfo = GeneratePatients(100);

foreach (var patient in patientsInfo)
{
    Console.WriteLine($"{patient.LastName} {patient.FirstName} ({patient.Gender}) - Born: {patient.BirthDate.ToShortDateString()}");
}

Console.ReadKey();

static List<GeneratePatientModel> GeneratePatients(int count)
{
    var random = new Random();
    var firstNames = new[] { "John", "Jane", "Michael", "Emily", "David", "Jessica", "William", "Ashley", "Christopher", "Sarah", "Andrew", "Brittany", "Joseph", "Amanda", "Daniel", "Melissa", "Matthew", "Stephanie", "Joshua", "Nicole" };

    var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };

    var patients = new List<GeneratePatientModel>();
    for (int i = 0; i < count; i++)
    {
        patients.Add(new GeneratePatientModel
        {
            FirstName = firstNames[random.Next(firstNames.Length)],
            LastName = lastNames[random.Next(lastNames.Length)],
            Gender = (Gender)random.Next(4), 
            BirthDate = new DateTime(random.Next(1950, 2005), random.Next(1, 13), random.Next(1, 29))
        });
    }
    return patients;
}