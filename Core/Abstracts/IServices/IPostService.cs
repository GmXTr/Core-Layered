using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Core.Abstracts.IServices
{
    public interface IPostService
    {
        Task<PostDetail> GetPostAsync(int postId);
        Task<IEnumerable<PostListItem>> GetPostsAsync(int page = 1, int per_page = 10, int categoryId = 0, string? tag = null);
        Task<int> GetPostCountAsync(int categoryId = 0, string? tag = null);
        Task<IEnumerable<CategoryListItem>> GetCategoriesAsync();

        Task CreatePostAsync(Post post, string[]? tags=null);
        Task ModifyPostAsync(PostDetail post);
    }
}
