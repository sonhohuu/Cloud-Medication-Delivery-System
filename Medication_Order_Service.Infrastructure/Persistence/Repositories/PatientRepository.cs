using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.MedicationOrders;
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

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<PatientEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity != null ? _mapper.Map<Patient>(entity) : null;
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
