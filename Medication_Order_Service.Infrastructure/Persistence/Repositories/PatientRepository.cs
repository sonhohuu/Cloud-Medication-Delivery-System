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

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
            if (request.PageNumber <= 0) request.PageNumber = 1;
            if (request.PageSize <= 0) request.PageSize = 10;

            var query = _context.Set<PatientEntity>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                query = query.Where(x => x.FullName.Contains(request.FullName));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            if (!string.IsNullOrWhiteSpace(request.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply pagination and execute query
            var entities = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            // Map entities to domain models
            var patients = _mapper.Map<List<Patient>>(entities);

            // Return paged result
            return new PagedList<Patient>(
                patients,
                totalCount,
                request.PageNumber,
                request.PageSize
            );
        }
    }
}
