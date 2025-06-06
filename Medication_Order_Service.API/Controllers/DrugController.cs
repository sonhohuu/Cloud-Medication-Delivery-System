using MediatR;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrug;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController(ISender sender, ILogger<DrugController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;
        [HttpPost]
        public async Task<IActionResult> CreateMedicationOrder([FromBody] CreateDrugCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
