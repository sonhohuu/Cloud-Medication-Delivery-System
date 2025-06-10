using AutoMapper;
using Medication_Order_Service.Application.Drugs.Queries.FilterDrug;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
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
    public class DrugRepository : RepositoryBase<Drug, DrugEntity>, IDrugRepository
    {
        public DrugRepository(MedicationOrderServiceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Drug?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<DrugEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<Drug>(entity) : null;
        }

        public async Task<PagedList<Drug>> FilterDrugAsync(FilterDrugQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize == 0 ? 10 : request.PageSize, 1, 100);

            var query = _context.Set<DrugEntity>().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{request.Name}%"));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == request.IsActive);
            }

            if (request.DrugCategoryId.HasValue && request.DrugCategoryId.Value != Guid.Empty)
            {
                query = query.Where(x => x.DrugCategoryId == request.DrugCategoryId.Value);
            }

            if (request.DosageFormTypeId.HasValue && request.DosageFormTypeId.Value != Guid.Empty)
            {
                query = query.Where(x => x.DosageFormId == request.DosageFormTypeId.Value);
            }

            var result = await query
                .Include(x => x.DrugCategory)
                .Include(x => x.DosageForm)
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
            var drugs = result.Select(x => _mapper.Map<Drug>(x.Data)).ToList();

            return new PagedList<Drug>(
                drugs,
                totalCount,
                request.PageNumber,
                request.PageSize
            );
        }
    }
}
