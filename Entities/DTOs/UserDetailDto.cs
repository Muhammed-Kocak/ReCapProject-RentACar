using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserDetailDto : IDto
    {
        public int UserDetailDtoId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}