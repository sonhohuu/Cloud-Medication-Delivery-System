using AutoMapper;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Drugs.Entities;
using Medication_Order_Service.Domain.MedicationOrders;
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
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedByAccountId, opt => opt.MapFrom(src => src.CreatedByAccountId))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.WaitingNumber, opt => opt.MapFrom(src => src.WaitingNumber))
                .ForMember(dest => dest.MedicationRoom, opt => opt.MapFrom(src => src.MedicationRoom))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                // Ignore properties not in domain model or handled elsewhere
                .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
                .ForMember(dest => dest.Bill, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            // Map MedicationOrder to MedicationOrderEntity (Domain -> Entity)
            CreateMap<MedicationOrder, MedicationOrderEntity>()
                //.ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedByAccountId, opt => opt.MapFrom(src => src.CreatedByAccountId))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.WaitingNumber, opt => opt.MapFrom(src => src.WaitingNumber))
                .ForMember(dest => dest.MedicationRoom, opt => opt.MapFrom(src => src.MedicationRoom))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                // Set default or ignored values for entity-specific properties
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID is typically set by DB
                .ForMember(dest => dest.DoctorId, opt => opt.Ignore()) // Not in domain model
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.ReasonCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByAccount, opt => opt.Ignore())
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ForMember(dest => dest.Bill, opt => opt.Ignore());

            // Map PatientEntity to Patient (Entity -> Domain)
            CreateMap<PatientEntity, Patient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Allergies, opt => opt.MapFrom(src => src.Allergies))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.IsTreating, opt => opt.MapFrom(src => src.IsTreating));

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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.DosageFormType, opt => opt.MapFrom(src => src.DosageForm))
                .ForMember(dest => dest.DrugCategory, opt => opt.MapFrom(src => src.DrugCategory));

            CreateMap<DosageForm, DosageFormEntity>();

            CreateMap<DosageFormEntity, DosageForm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<DrugCategory, DrugCategoryEntity>();
            CreateMap<DrugCategoryEntity, DrugCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
