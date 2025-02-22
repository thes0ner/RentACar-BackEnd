using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Customer : BaseEntity
    {

        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public CustomerStatus CustomerStatus { get; set; }


        //Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
