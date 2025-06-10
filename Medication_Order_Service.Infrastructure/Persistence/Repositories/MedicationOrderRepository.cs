using AutoMapper;
using Medication_Order_Service.Application.MedicationOrders.Queries.FilterMedicationOrder;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.MedicationOrders;
using Medication_Order_Service.Domain.Patients;
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

        public async Task<MedicationOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
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

        public async Task<PagedList<MedicationOrder>> FilterMedicationOrderAsync(FilterMedicationOrderQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize == 0 ? 10 : request.PageSize, 1, 100);

            var query = _context.Set<MedicationOrderEntity>().AsNoTracking();

            if (request.PatientId.HasValue && request.PatientId.Value != Guid.Empty)
            {
                query = query.Where(x => x.PatientId == request.PatientId.Value);
            }

            var result = await query
                .Include(x => x.Patient)
                .Include(x => x.Items)
                .Include(x => x.Bill)
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    Data = x,
                    TotalCount = query.Count()
                })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var totalCount = result.FirstOrDefault()?.TotalCount ?? 0;
            var medicationOrders = result.Select(x => _mapper.Map<MedicationOrder>(x.Data)).ToList();

            return new PagedList<MedicationOrder>(
                medicationOrders,
                totalCount,
                request.PageNumber,
                request.PageSize
            );
        }

    }
}
