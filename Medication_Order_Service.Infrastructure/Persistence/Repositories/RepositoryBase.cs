using AutoMapper;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<TDomain, TEntity>
    where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly IMapper _mapper;

        protected RepositoryBase(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected TEntity MapToEntity(TDomain domain) => _mapper.Map<TEntity>(domain);
        protected TDomain MapToDomain(TEntity entity) => _mapper.Map<TDomain>(entity);

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task AddAsync(TDomain domain, CancellationToken cancellationToken)
        {
            var entity = MapToEntity(domain);
            await GetSet().AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(TDomain domain, CancellationToken cancellationToken)
        {
            var entity = MapToEntity(domain);
            GetSet().Update(entity);
        }

        protected virtual DbSet<TEntity> GetSet()
        {
            return _context.Set<TEntity>();
        }
        public async Task<List<TDomain>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await GetSet().ToListAsync(cancellationToken);
            return entities.Select(MapToDomain).ToList();
        }
    }
}
