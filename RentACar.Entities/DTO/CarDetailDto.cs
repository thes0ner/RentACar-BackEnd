using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.DTO
{
    public class CarDetailDto : BaseEntity
    {

        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Vehicle { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCity { get; set; }
        public string LocationAddress { get; set; }
        public decimal DailyPrice { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public CarStatus Status { get; set; }

    }
}
