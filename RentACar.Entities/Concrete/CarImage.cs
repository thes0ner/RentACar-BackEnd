using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class CarImage : BaseEntity
    {

        // Properties
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        // Foreign Key
        public int CarId { get; set; }

        // Navigation properties
        public Car Car { get; set; }
    }
}
