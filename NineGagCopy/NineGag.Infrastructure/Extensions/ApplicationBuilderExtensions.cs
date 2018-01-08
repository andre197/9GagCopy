namespace NineGag.Infrastructure.Extensions
{
    using AutoMapper;
    using BindingModels;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using ViewModels;

    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureAutomapper(this IApplicationBuilder builder)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, DetailedPostViewModel>()
                    .ForMember(
                        dest => dest.PostUpvotesCount,
                        opts => opts.MapFrom(
                            src => src.PostUpvotes.Count))
                    .ForMember(
                        dest => dest.CommentsCount,
                        opts => opts.MapFrom(
                            src => src.Comments.Count));

                cfg.CreateMap<PostBindingModel, Post>();
            });
        }
    }
}
