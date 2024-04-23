using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class PostRepo : GenericRepository<Post>, IPostRepo
    {
        public PostRepo(BlogContext context) : base(context)
        {
        }
    }
}
