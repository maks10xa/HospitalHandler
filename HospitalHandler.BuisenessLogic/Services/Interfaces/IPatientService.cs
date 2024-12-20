using HospitalHandler.BuisenessLogic.Models;
using HospitalHandler.Enteties.Entities;

namespace HospitalHandler.BuisenessLogic.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetPatientById(Guid Id);
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Patient>> GetPatientsByBirthDate(string birthDateInput);
        Task<Patient> CreatePatient(PatientCreateModel type);
        Task<PatientUpdateModel> UpdatePatient(PatientUpdateModel type);
        Task RemovePatient(Guid id);
    }
}
