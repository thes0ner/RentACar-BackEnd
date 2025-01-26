using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class CarImage : BaseEntity
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        //navigation properties
        public Car Car { get; set; }
    }
}
