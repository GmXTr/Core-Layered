using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;


namespace Business.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreatePostAsync(Post post, string[]? tags = null)
        {
            await unitOfWork.PostRepo.CreateOneAsync(post);
            await unitOfWork.CommitAsync();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    if (!await unitOfWork.TagRepo.AnyAsync(x => x.Title == tag && x.PostId == post.Id))
                    {
                        await unitOfWork.TagRepo.CreateOneAsync(new Tag { Title = tag, PostId = post.Id });
                    }
                }
            }
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CategoryListItem>> GetCategoriesAsync()
        {
            return mapper.Map<List<CategoryListItem>>(await unitOfWork.CategoryRepo.ReadManyAsync());
        }

        public async Task<PostDetail> GetPostAsync(int postId)
        {
            var post = await unitOfWork.PostRepo.ReadOneAsync(postId);
            return mapper.Map<PostDetail>(post);
        }

        public Task<int> GetPostCountAsync(int categoryId = 0, string? tag = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostListItem>> GetPostsAsync(int page = 1, int per_page = 10, int categoryId = 0, string? tag = null)
        {
            var data = await unitOfWork.PostRepo.ReadManyAsync(null, new string[] { "Tags", "Category" });
            return mapper.Map<List<PostListItem>>(data);
        }

        public async Task ModifyPostAsync(PostDetail post)
        {
            var entity = mapper.Map<Post>(post);
            await unitOfWork.PostRepo.UpdateOneAsync(entity);
            await unitOfWork.TagRepo.DeleteManyAsync(x => x.PostId == post.Id);
            if (post.Tags != null)
            {
                foreach (var tag in post.Tags)
                {
                    if (!await unitOfWork.TagRepo.AnyAsync(x => x.Title == tag && x.PostId == post.Id))
                    {
                        await unitOfWork.TagRepo.CreateOneAsync(new Tag { Title = tag, PostId = post.Id });
                    }
                }
            }
            await unitOfWork.CommitAsync();
        }
    }
}
