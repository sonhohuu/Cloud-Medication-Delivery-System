using AutoMapper;
using Medication_Order_Service.Domain.Accounts;
using Medication_Order_Service.Domain.Accounts.Entities;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Drugs.Entities;
using Medication_Order_Service.Domain.MedicationOrders;
using Medication_Order_Service.Domain.MedicationOrders.Entities;
using Medication_Order_Service.Domain.Patients;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(Guid), typeof(Id<>))
                .ConvertUsing(typeof(GeneralFunc.GuidToIdTypeConverter<>));

            // Map MedicationOrderEntity to MedicationOrder (Entity -> Domain)
            CreateMap<MedicationOrderEntity, MedicationOrder>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                // Ignore properties not in domain model or handled elsewhere
                .ForMember(dest => dest.Bill, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            // Map MedicationOrder to MedicationOrderEntity (Domain -> Entity)
            CreateMap<MedicationOrder, MedicationOrderEntity>()
                // Set default or ignored values for entity-specific properties
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ForMember(dest => dest.Bill, opt => opt.Ignore());

            CreateMap<MedicationOrderItem, MedicationOrderItemEntity>();

            CreateMap<MedicationOrderItemEntity, MedicationOrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Map PatientEntity to Patient (Entity -> Domain)
            CreateMap<PatientEntity, Patient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Map Patient to PatientEntity (Domain -> Entity)
            CreateMap<Patient, PatientEntity>()
                .ForMember(dest => dest.MedicationOrders, opt => opt.Ignore()); // Handled separately if needed

            CreateMap<Drug, DrugEntity>()
                .ForMember(dest => dest.DosageForm, opt => opt.Ignore())
                .ForMember(dest => dest.DrugCategory, opt => opt.Ignore())
                .ForMember(dest => dest.DrugCategoryId, opt => opt.MapFrom(src => src.DrugCategory.Id.Value))
                .ForMember(dest => dest.DosageFormId, opt => opt.MapFrom(src => src.DosageFormType.Id.Value));

            CreateMap<DrugEntity, Drug>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DosageFormType, opt => opt.MapFrom(src => src.DosageForm))
                .ForMember(dest => dest.DrugCategory, opt => opt.MapFrom(src => src.DrugCategory));

            CreateMap<DosageForm, DosageFormEntity>();

            CreateMap<DosageFormEntity, DosageForm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<DrugCategory, DrugCategoryEntity>();

            CreateMap<DrugCategoryEntity, DrugCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Account, AccountEntity>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Roles.Id));

            CreateMap<AccountEntity, Account>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Role));

            CreateMap<Roles, Role>();

            CreateMap<Role, Roles>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
