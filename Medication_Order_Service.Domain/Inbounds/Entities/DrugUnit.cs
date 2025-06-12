using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Inbounds.Entities
{
    public class DrugUnit : Entity<DrugUnit>
    {
        public string UnitName { get; private set; }
        public Guid? ParentUnitId { get; private set; }
        public int ConversionRate { get; private set; }
        public bool IsBaseUnit { get; private set; }

        private DrugUnit(Id<DrugUnit> id) : base(id)
        {
        }
        public static DrugUnit Create(string unitName, int conversionRate, bool isBaseUnit, Guid? parentUnitId = null)
        {
            return new DrugUnit(Id<DrugUnit>.New())
            {
                UnitName = unitName,
                ConversionRate = conversionRate,
                IsBaseUnit = isBaseUnit,
                ParentUnitId = parentUnitId
            };
        }


    }
}
