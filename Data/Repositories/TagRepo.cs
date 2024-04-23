using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class TagRepo : GenericRepository<Tag>, ITagRepo
    {
        public TagRepo(BlogContext context) : base(context)
        {
        }
    }
}
