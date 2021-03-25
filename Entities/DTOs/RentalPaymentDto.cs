using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalPaymentDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
