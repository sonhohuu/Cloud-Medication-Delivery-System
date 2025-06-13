using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Accounts.Entities;
using Medication_Order_Service.Domain.Patients;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<Roles, Role>, IRoleRepository
    {
        public RoleRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<Roles?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<Role>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<Roles>(entity) : null;
        }
    }
}
