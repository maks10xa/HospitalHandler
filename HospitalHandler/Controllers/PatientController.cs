using Microsoft.AspNetCore.Mvc;
using HospitalHandler.BuisenessLogic.Services.Interfaces;
using HospitalHandler.BuisenessLogic.Models;

namespace HospitalHandler.Controllers
{
    [Route("api/v1/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// get patient
        /// </summary>
        /// <param name="id">patient Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _patientService.GetPatientById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get all patients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                return Ok(await _patientService.GetPatients());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get patients by date
        /// </summary>
        /// <param name="birthDate">input birthdate in correct format</param>
        /// <returns></returns>
        [HttpGet]
        [Route("byDate")]
        public async Task<IActionResult> GetPatientsByBirthDate(string birthDate)
        {
            try
            {
                return Ok(await _patientService.GetPatientsByBirthDate(birthDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// create new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreatePatient([FromForm]PatientCreateModel patient)
        {
            try
            {
                return Ok(await _patientService.CreatePatient(patient));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// update patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<IActionResult> UpdatePatient([FromForm]PatientUpdateModel patient)
        {
            try
            {
                return Ok(await _patientService.UpdatePatient(patient));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// remove patient
        /// </summary>
        /// <param name="id">patient Id</param>
        /// <returns></returns>
        [HttpDelete("")]
        public async Task<IActionResult> RemovePatient(Guid id)
        {
            try
            {
                await _patientService.RemovePatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
