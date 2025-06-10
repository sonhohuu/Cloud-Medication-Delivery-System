using MediatR;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrugCategory;
using Medication_Order_Service.Application.Drugs.Queries.GetAllDrugCategory;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugCategoryController(ISender sender, ILogger<DrugCategoryController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateDrugCategory([FromBody] CreateDrugCategoryCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrugCategory()
        {
            var result = await _sender.Send(new GetAllDrugCategoryQuery());
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
