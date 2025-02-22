using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class CreditCard : Payment
    {
        // Properties
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public int CardLimit { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }
    }
}
