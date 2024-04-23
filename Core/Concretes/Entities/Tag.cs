using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class Tag : BaseEntity
    {
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
