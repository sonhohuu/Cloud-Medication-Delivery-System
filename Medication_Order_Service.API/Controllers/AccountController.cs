using MediatR;
using Medication_Order_Service.Application.Accounts.Commands.CreateAccount;
using Medication_Order_Service.Application.Accounts.Queries.Login;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrugDosageForm;
using Microsoft.AspNetCore.Mvc;

namespace Medication_Order_Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(ISender sender, ILogger<AccountController> logger) : BaseController(logger)
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var result = await _sender.Send(query);
            if (result.IsSuccess)
                return Ok(result.Value);
            return HandleError(result.Error);
        }
    }
}
