using MediatR;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrugDosageForm;
using Medication_Order_Service.Application.Drugs.Queries.GetAllDrugCategory;
using Medication_Order_Service.Application.Drugs.Queries.GetAllDrugDosageForm;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DosageFormController(ISender sender, ILogger<DosageFormController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateDosageForm([FromBody] CreateDrugDosageFormCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDosageForm()
        {
            var result = await _sender.Send(new GetAllDrugDosageFormQuery());
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
