using Medication_Order_Service.Common;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Inbounds.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Inbounds
{
    public class Inbound : AggregateRoot<Inbound>
    {
        public string InboundCode { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Supplier Supplier { get; private set; }
        public InboundType InboundType { get; private set; }
        public InboundStatus Status { get; private set; }
        public string? Note { get; private set; }
        public decimal? TotalPrice { get; private set; }
        public IReadOnlyCollection<InboundDetail> Items => _items.AsReadOnly();
        private readonly List<InboundDetail> _items = new();
        private Inbound(Id<Inbound> id) : base(id)
        {
        }
        public static Inbound Create(Supplier supplier, InboundType inboundType, string? note)
        {
            return new Inbound(Id<Inbound>.New())
            {
                InboundCode = GenerateInboundCode(),
                CreatedAt = DateTime.Now,
                Supplier = supplier,
                InboundType = inboundType,
                Status = InboundStatus.Pending,
                Note = note
            };
        }
        public void AddItem(InboundDetail item)
        {
            _items.Add(item);
        }

        private static string GenerateInboundCode()
        {
            var random = new Random();

            // 10-digit DateTime: yyMMddHHmm
            string datePart = DateTime.UtcNow.ToString("yyMMddHHmm");

            return $"IC{datePart}";
        }
    }
}
