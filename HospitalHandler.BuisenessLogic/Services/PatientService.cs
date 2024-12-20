using HospitalHandler.BuisenessLogic.Models;
using HospitalHandler.BuisenessLogic.Services.Interfaces;
using HospitalHandler.Enteties.Data;
using HospitalHandler.Enteties.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HospitalHandler.BuisenessLogic.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;

        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientById(Guid id) => await _context.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Patient> CreatePatient(PatientCreateModel patient)
        {
            var guid = Guid.NewGuid();

            var patientSaveModel = new Patient()
            {
                Id = guid,
                Gender = patient.Gender.ToString(),
                BirthdDate = patient.BirthdDate,
                Active = patient.Active
            };

            var nameSaveModel = new Name()
            {
                PatientId = guid,
                Use = patient.Use,
                Family = patient.Family,
                FirstName = patient.FirstName,
                Surname = patient.Surname
            };

            await _context.Patients!.AddAsync(patientSaveModel);
            await _context.Names!.AddAsync(nameSaveModel);

            await _context.SaveChangesAsync();

            return patientSaveModel;
        }

        public async Task<PatientUpdateModel> UpdatePatient(PatientUpdateModel patient)
        {
            var mappedPatient = await _context.Patients!.FindAsync(patient.Id);
            var mappedName = await _context.Names!.FindAsync(patient.NameId);

            if (mappedPatient is null || mappedName is null) { throw new Exception("Patient not found!"); }

            mappedPatient.Gender = patient.Gender.ToString();
            mappedPatient.BirthdDate = patient.BirthdDate;
            mappedPatient.Active = patient.Active;

            mappedName.Use = patient.Use;
            mappedName.Family = patient.Family;
            mappedName.FirstName = patient.FirstName;
            mappedName.Surname = patient.Surname;

            _context.Patients.Update(mappedPatient);
            _context.Names!.Update(mappedName);

            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task RemovePatient(Guid id)
        {
            var patient = await _context.Patients!.FindAsync(id);
            if (patient is null) { throw new Exception("Patient not found!"); }

            _context.Patients.Remove(patient);
        }

        public async Task<IEnumerable<Patient>> GetPatients() => await _context.Patients!.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Patient>> GetPatientsByBirthDate(string birthDateInput)
        {
            DateTime? birthDate;

            try
            {
                birthDate = DateTime.ParseExact(birthDateInput, "yyyy-MM-ddTHH:mm:ss.fffffffZ", CultureInfo.InvariantCulture);
                //If Z is absent (no UTC) then try this one, adding UTC
                if (birthDate == null)
                {
                    birthDate = DateTime.ParseExact(birthDateInput, "yyyy-MM-ddTHH:mm:ss.fffffff", CultureInfo.InvariantCulture).ToUniversalTime();
                }
                //If above fails try without fractional seconds
                if (birthDate == null)
                {
                    birthDate = DateTime.ParseExact(birthDateInput, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                    //If Z is absent (no UTC) then try this one, adding UTC
                    if (birthDate == null)
                    {
                        birthDate = DateTime.ParseExact(birthDateInput, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture).ToUniversalTime();
                    }
                }
                //If above fails try without time
                if (birthDate == null)
                {
                    birthDate = DateTime.ParseExact(birthDateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }


            }
            catch (FormatException)
            {
                throw new Exception($"Invalid date format: {birthDateInput}");
            }

            var foundPatients = await _context.Patients!.Where(p => p.BirthdDate.Date == birthDate.Value.Date).AsNoTracking().ToListAsync();

            return foundPatients;
        }
    }
}
