﻿using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class User : BaseEntity
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        //public byte[] PasswordSalt { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }


        // Navigation properties
        public Customer Customer { get; set; }
    }
}
