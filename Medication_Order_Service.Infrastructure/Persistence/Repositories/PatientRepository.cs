using AutoMapper;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
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
    public class PatientRepository : RepositoryBase<Patient, PatientEntity>, IPatientRepository
    {
        public PatientRepository(MedicationOrderServiceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<PatientEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<Patient>(entity) : null;
        }

        public async Task<PagedList<Patient>> FilterPatientAsync(FilterPatientQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize == 0 ? 10 : request.PageSize, 1, 100);

            var query = _context.Set<PatientEntity>().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                query = query.Where(x => EF.Functions.Like(x.FullName, $"%{request.FullName}%"));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{request.Email}%"));
            }

            if (!string.IsNullOrWhiteSpace(request.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            var result = await query
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
            var patients = result.Select(x => _mapper.Map<Patient>(x.Data)).ToList();

            return new PagedList<Patient>(
                patients,
                totalCount,
                request.PageNumber,
                request.PageSize
            );
        }
    }
}
