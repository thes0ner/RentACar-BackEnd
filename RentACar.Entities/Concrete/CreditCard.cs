using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class CreditCard : BaseEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public int Months { get; set; }
        public int Year { get; set; }

        //Navigation properties
        public Customer Customer { get; set; }
    }
}
