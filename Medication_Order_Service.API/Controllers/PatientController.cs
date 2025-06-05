using MediatR;
using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Medication_Order_Service.Application.Patients.Commands.ActivatePatient;
using Medication_Order_Service.Application.Patients.Commands.AddPatient;
using Medication_Order_Service.Application.Patients.Commands.DeactivatePatient;
using Medication_Order_Service.Application.Patients.Commands.UpdatePatient;
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

        [HttpPut("deactivate")]
        public async Task<IActionResult> DeactivatePatient([FromBody] DeactivatePatientCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPut("activate")]
        public async Task<IActionResult> ActivatePatient([FromBody] ActivatePatientCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
