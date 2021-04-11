using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int findeksId { get; set; }
        public int CustomerId { get; set; }
        public string NationalIdentity { get; set; }
        public short Score { get; set; }
    }
}