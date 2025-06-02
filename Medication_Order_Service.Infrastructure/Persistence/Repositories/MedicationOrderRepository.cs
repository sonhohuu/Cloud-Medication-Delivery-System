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
    public class MedicationOrderRepository : IMedicationOrderRepository
    {
        private readonly MedicationOrderServiceDbContext _dbContext;
        private readonly IMapper _mapper;
        public MedicationOrderRepository(MedicationOrderServiceDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task AddAsync(MedicationOrder entity, CancellationToken cancellationToken)
        {
            var medicationEntity = _mapper.Map<MedicationOrderEntity>(entity);
            await _dbContext.AddAsync(medicationEntity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicationOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MedicationOrder?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MedicationOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
