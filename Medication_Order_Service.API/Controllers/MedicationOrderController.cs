using MediatR;
using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationOrderController(ISender sender, ILogger<MedicationOrderController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;
        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] RegisterMedicationOrderCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
