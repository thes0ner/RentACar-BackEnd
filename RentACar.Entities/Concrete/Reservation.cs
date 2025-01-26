using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Reservation : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}
