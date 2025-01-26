using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class Car : BaseEntity
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public int VehicleId { get; set; }
        public int LocationId { get; set; }
        public decimal DailyPrice { get; set; }
        public string? Model { get; set; } 
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string? Description { get; set; }
        public CarStatus Status { get; set; }


        //Navigation properties
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public FuelType FuelType { get; set; }
        public Location Location { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public VehicleType VehicleType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<CarImage> CarImages { get; set; }


    }
}
