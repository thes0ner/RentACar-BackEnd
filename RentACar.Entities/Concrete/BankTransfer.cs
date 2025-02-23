using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class BankTransfer : Payment
    {
        // Properties
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }

        public bool IsDeleted { get; set; }
    }
}
