using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Reservation : BaseEntity
    {

        // Properties
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }
        public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Pending;


        // Foreign keys
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        
        
        // Navigation properties
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Payment Payment { get; set; }

    }
}
