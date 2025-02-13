using RentACar.Core.Entities.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public CustomerStatus CustomerStatus { get; set; }


        // Navigation properties
        public User User { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
    }
}
