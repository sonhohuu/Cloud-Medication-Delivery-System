using MediatR;
using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Medication_Order_Service.Application.Patients.Commands.ActivatePatient;
using Medication_Order_Service.Application.Patients.Commands.AddPatient;
using Medication_Order_Service.Application.Patients.Commands.DeactivatePatient;
using Medication_Order_Service.Application.Patients.Commands.UpdatePatient;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController(ISender sender, ILogger<MedicationOrderController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] AddPatientCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivatePatient([FromRoute] Guid id)
        {
            var command = new DeactivatePatientCommand { Id = id };
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivatePatient([FromRoute] Guid id)
        {
            var command = new ActivatePatientCommand { Id = id };
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> FindAsync([FromQuery] FilterPatientQuery command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
