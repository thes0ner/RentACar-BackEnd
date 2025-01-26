using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class Rental : BaseEntity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsReturned { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Invoice Invoice { get; set; }

    }
}
