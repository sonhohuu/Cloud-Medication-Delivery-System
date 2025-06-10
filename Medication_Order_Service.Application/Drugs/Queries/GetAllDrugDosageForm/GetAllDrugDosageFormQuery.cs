using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Queries.GetAllDrugDosageForm
{
    public class GetAllDrugDosageFormQuery : IQuery<List<DosageForm>>
    {
    }
}
