using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class Category : BaseEntity
    {
        public virtual ICollection<Post>? Posts { get; set; } = new HashSet<Post>();
    }
}
