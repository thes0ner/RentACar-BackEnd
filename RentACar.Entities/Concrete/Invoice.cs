using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACar.Entities.Concrete
{
    public class Invoice : BaseEntity
    {
        // Properties
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }


        // Foreign Key
        public int RentalId { get; set; }

        // Navigation property
        public Rental Rental { get; set; }
    }
}
