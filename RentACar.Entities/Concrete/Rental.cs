using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Rental : BaseEntity
    {

        // Properties
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsReturned { get; set; }


        // Foreign Keys
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        // Navigation properties
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
