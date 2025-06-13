using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Inbounds.Entities
{
    public class InboundDetail : Entity<InboundDetail>
    {
        public Guid LotId { get; private set; }
        public Guid DrugUnitId { get; private set; }
        public int ExpectedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public decimal UnitPrice { get; set; }

        private InboundDetail(Id<InboundDetail> id) : base(id)
        {
        }

        public static InboundDetail Create(Guid drugUnitId, int expectedQuantity, decimal unitPrice)
        {
            return new InboundDetail(Id<InboundDetail>.New())
            {
                DrugUnitId = drugUnitId,
                ExpectedQuantity = expectedQuantity,
                ActualQuantity = expectedQuantity,
                UnitPrice = unitPrice
            };
        }

    }
}
