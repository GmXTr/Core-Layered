using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPostRepo PostRepo { get; }
        ITagRepo TagRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        Task CommitAsync();
    }
}
