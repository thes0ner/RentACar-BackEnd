using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class Brand :BaseEntity
    {
        public string Name { get; set; }
       
        // Navigation properties
        public ICollection<Car> Cars { get; set; }
    }
}
