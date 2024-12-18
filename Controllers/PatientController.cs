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
        /// asdasdasd
        /// </summary>
        /// <param name="id"></param>
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

        [HttpDelete("")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                await _patientService.DeletePatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
