using AutoMapper;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.MedicationOrders.Entities;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class MedicationOrderItemRepository : RepositoryBase<MedicationOrderItem, MedicationOrderItemEntity>, IMedicationOrderItemRepository
    {
        public MedicationOrderItemRepository(MedicationOrderServiceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
