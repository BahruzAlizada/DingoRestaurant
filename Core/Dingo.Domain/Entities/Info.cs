using Dingo.Domain.Common;

namespace Dingo.Domain.Entities
{
    public class Info : BaseEntity
    {
        public string? Address { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
