using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Transmission : BaseEntity
    {
        // Properties
        public string Type { get; set; }
        
        
        // Navigation properties
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
