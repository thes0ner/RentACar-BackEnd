using RentACar.Core.Entities.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.DTO_s
{
    public class CarSearchCriteriaDto : BaseEntity
    {
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public int? MinMileage { get; set; }
        public int? MaxMileage { get; set; }
        public CarStatus? Status { get; set; }
    }
}
