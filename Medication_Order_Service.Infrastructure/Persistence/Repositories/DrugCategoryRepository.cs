using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Drugs.Entities;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class DrugCategoryRepository : RepositoryBase<DrugCategory, DrugCategoryEntity>, IDrugCategoryRepository
    {
        public DrugCategoryRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<DrugCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<DrugCategoryEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<DrugCategory>(entity) : null;
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Set<DrugCategoryEntity>().AsNoTracking().AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()), cancellationToken);
        }
    }
}
