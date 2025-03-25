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
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
            .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.ColorId))
            .ForMember(dest => dest.FuelId, opt => opt.MapFrom(src => src.FuelId))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.TransmissionId, opt => opt.MapFrom(src => src.TransmissionId))
            .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.Color, opt => opt.Ignore())
            .ForMember(dest => dest.Fuel, opt => opt.Ignore())
            .ForMember(dest => dest.Transmission, opt => opt.Ignore())
            .ForMember(dest => dest.Vehicle, opt => opt.Ignore())
            .ForMember(dest => dest.Location, opt => opt.Ignore())
            .ForMember(dest => dest.CarImages, opt => opt.Ignore())
            .ForMember(dest => dest.Rentals, opt => opt.Ignore())
            .ForMember(dest => dest.Reservations, opt => opt.Ignore());
        }
    }
}
