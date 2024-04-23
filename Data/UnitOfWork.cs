using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext context;

        public UnitOfWork(BlogContext context)
        {
            this.context = context;
        }

        private IPostRepo? postRepo;
        public IPostRepo PostRepo => postRepo ??= new PostRepo(context);

        private ITagRepo? tagRepo;
        public ITagRepo TagRepo => tagRepo ??= new TagRepo(context);

        private ICategoryRepo? categoryRepo;
        public ICategoryRepo CategoryRepo => categoryRepo ??= new CategoryRepo(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();
    }
}
