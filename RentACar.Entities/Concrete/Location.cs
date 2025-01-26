using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Location : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
