using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.DTO
{
    public class CreateReservationDto :BaseEntity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public ReservationStatus Status { get; set; }

    }
}
