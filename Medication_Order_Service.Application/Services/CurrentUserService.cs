using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId => Guid.Parse(
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));

        public string? UserName =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

        public string? Email =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

        public string? Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
    }
}
