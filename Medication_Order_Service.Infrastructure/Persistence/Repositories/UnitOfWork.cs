using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MedicationOrderServiceDbContext _context;
        private readonly IMapper _mapper;

        public IMedicationOrderRepository MedicationOrderRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }
        public IDrugRepository DrugRepository { get; private set; }
        public IDrugCategoryRepository DrugCategoryRepository { get; private set; }
        public IDrugDosageFormRepository DrugDosageFormRepository { get; private set; }
        public UnitOfWork(MedicationOrderServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            MedicationOrderRepository ??= new MedicationOrderRepository(_context, mapper);
            PatientRepository ??= new PatientRepository(_context, mapper);
            DrugRepository ??= new DrugRepository(_context, mapper);
            DrugCategoryRepository ??= new DrugCategoryRepository(_context, mapper);
            DrugDosageFormRepository ??= new DrugDosageFormRepository(_context, mapper);
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}