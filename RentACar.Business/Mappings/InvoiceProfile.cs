using AutoMapper;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceDto, Invoice>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
               .ForMember(dest => dest.PaidAmount, opt => opt.MapFrom(src => src.PaidAmount))
               .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
               .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
               .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.InvoiceDate))
               .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
               .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
               .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.RentalId));

        }
    }
}
