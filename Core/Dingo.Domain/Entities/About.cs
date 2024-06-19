using Dingo.Domain.Common;

namespace Dingo.Domain.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
