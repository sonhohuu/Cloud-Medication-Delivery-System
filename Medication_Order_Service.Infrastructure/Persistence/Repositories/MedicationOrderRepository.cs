using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.MedicationOrders;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class MedicationOrderRepository : RepositoryBase<MedicationOrder, MedicationOrderEntity>, IMedicationOrderRepository
    {
        public MedicationOrderRepository(MedicationOrderServiceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<MedicationOrder?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<MedicationOrderEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<MedicationOrder>(entity) : null;
        }

        public async Task<IEnumerable<MedicationOrder>> GetByWhereAsync(
            Expression<Func<MedicationOrderEntity, bool>> predicate)
        {
            var entities = await _context.Set<MedicationOrderEntity>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(e => _mapper.Map<MedicationOrder>(e));
        }


        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Set<MedicationOrderEntity>().AnyAsync(x => x.Id == id);
        }

    }
}
