﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IMedicationOrderRepository MedicationOrderRepository { get; }
        IMedicationOrderItemRepository MedicationOrderItemRepository { get; }
        IPatientRepository PatientRepository { get; }
        IDrugRepository DrugRepository { get; }
        IDrugCategoryRepository DrugCategoryRepository { get; }
        IDrugDosageFormRepository DrugDosageFormRepository { get; }
    }
}
