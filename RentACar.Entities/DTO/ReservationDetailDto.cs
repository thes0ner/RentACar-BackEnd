using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.DTO
{
    public class ReservationDetailDto : BaseEntity
    {
        // Reservation Details
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        // Customer Details
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Car Details
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }


        // Calculated Fields
        public int TotalDays => (DropOffDate - PickUpDate).Days;
        public decimal EstimatedPrice => DailyPrice * TotalDays;
    }
}
