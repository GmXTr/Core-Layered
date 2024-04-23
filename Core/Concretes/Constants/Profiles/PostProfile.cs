using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Core.Concretes.Constants.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDetail>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Title))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Title).ToArray()));

            CreateMap<Post, PostListItem>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Title))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Title).ToArray()))
                .ForMember(dest => dest.ShortContent, opt => opt.MapFrom(src => src.Content.Substring(0, src.Content.Length > 150 ? 150 : src.Content.Length)));

            CreateMap<Category, CategoryListItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));


        }
    }
}
