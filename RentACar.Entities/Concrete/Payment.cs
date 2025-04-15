using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public abstract class Payment : BaseEntity
    {

        // Properties
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }

        // Navigation properties
        public int RentalId { get; set; }
        public int ReservationId { get; set; }
        public Rental Rental { get; set; }
        public Reservation Reservation { get; set; }

    }
}
