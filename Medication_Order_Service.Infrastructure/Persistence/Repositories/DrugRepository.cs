using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class DrugRepository : RepositoryBase<Drug, DrugEntity>, IDrugRepository
    {
        public DrugRepository(MedicationOrderServiceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Drug?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<DrugEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<Drug>(entity) : null;
        }

        public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
