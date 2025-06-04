using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Drugs
{
    public sealed class Drug 
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public string DosageForm { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }

        private Drug() { }

        private Drug(string name, string description, string manufacturer, string dosageForm, decimal price)
        {
            name.EnsureNonEmpty(nameof(name));
            description.EnsureNonEmpty(nameof(description));
            manufacturer.EnsureNonEmpty(nameof(manufacturer));
            dosageForm.EnsureNonEmpty(nameof(dosageForm));
            price.EnsureNonNegative(nameof(price));

            Name = name;
            Description = description;
            Manufacturer = manufacturer;
            DosageForm = dosageForm;
            Price = price;
            IsActive = true; // Default value
        }

        public static Drug Create(string name, string description, string manufacturer, string dosageForm, decimal price)
        {
            return new Drug(name, description, manufacturer, dosageForm, price);
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
