using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.DTO
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsReturned { get; set; }
        public bool IsDeleted { get; set; }

    }
}
