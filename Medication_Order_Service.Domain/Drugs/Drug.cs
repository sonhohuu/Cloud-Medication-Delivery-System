using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Drugs
{
    public class Drug : AggregateRoot<Drug>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; } = true;
        public string SKU { get; private set; }
        public DrugCategory DrugCategory { get; private set; }
        public DosageForm DosageFormType { get; private set; }
        private Drug(Id<Drug> id) : base(id)
        {
        }

        public static Drug Create(string name, string description, decimal price, string SKU, DrugCategory drugCategory, DosageForm dosageForm)
        {
            name.EnsureNonEmpty(nameof(name));
            description.EnsureNonEmpty(nameof(description));
            price.EnsureGreaterThan(0, nameof(price));

            var drug = new Drug(Id<Drug>.New())
            {
                Name = name,
                Description = description,
                Price = price,
                SKU = SKU,
                DrugCategory = drugCategory,
                DosageFormType = dosageForm
            };

            ///Raise Domain Events Here

            return drug;
        }

        public void Update(string? name, string? description, decimal? price, DrugCategory? drugCategory, DosageForm? dosageForm)
        {
            if (name != null)
            {
                name.EnsureNonEmpty(nameof(name));
                Name = name;
            }
            if (description != null)
            {
                description.EnsureNonEmpty(nameof(description));
                Description = description;
            }
            if (price.HasValue)
            {
                price?.EnsureNonNegative(nameof(price));
                Price = price.Value;
            }

            if (drugCategory != null)
            {
                DrugCategory = drugCategory;
            }

            if (dosageForm != null)
            {
                DosageFormType = dosageForm;
            }

            ///Raise Domain Events Here
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}
