using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Services
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string? UserName { get; }
        string? Email { get; }
        string? Role { get; }
    }
}
