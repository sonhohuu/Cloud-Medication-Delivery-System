using AutoMapper;
using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Profiles
{
    public static class GeneralFunc
    {
        public class GuidToIdTypeConverter<T> : ITypeConverter<Guid, Id<T>>
        {
            public Id<T> Convert(Guid source, Id<T> destination, ResolutionContext context)
            {
                Console.WriteLine("Guid -> Id");
                return new Id<T>(source);
            }
        }
    }
}
