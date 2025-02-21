using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class Transmission : BaseEntity
    {
        public string Type { get; set; }
        
        // Navigation properties
        public ICollection<Car> Cars { get; set; }

        public Transmission()
        {
            Cars = new List<Car>();
        }

    }
}
