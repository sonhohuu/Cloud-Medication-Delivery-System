using MediatR;
using Medication_Order_Service.Application.MedicationOrders.Commands.AddMedicationOrderItem;
using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Medication_Order_Service.Application.MedicationOrders.Queries.FilterMedicationOrder;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationOrderController(ISender sender, ILogger<MedicationOrderController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateMedicationOrder([FromBody] RegisterMedicationOrderCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPut("add-items")]
        public async Task<IActionResult> AddMedicationOrderItem([FromBody] AddMedicationOrderItemCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpGet()]
        public async Task<IActionResult> FilterMedicationOrder([FromQuery] FilterMedicationOrderQuery query)
        {
            var result = await _sender.Send(query);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
