using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto :IDto
    {
        public int RentalDtoId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarDesctiption { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }


       


    }
}
