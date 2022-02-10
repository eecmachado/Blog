using AutoMapper;
using Blog.Application.UseCases.ViewModels;
using Blog.Domain.DomainModels;
using Blog.Infra.EntityFramework.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Infra.CrossCutting.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<IEnumerable<CommentModel>, CommentViewModel>()
                .ForMember(d => d.Posts, opt => opt.MapFrom(src =>
                    src.Select(s => new PostViewModel
                    {
                        Id = s.Id,
                        Created = s.Created,
                        Message = s.Message,
                        Title = s.Title,
                        UserId = s.UserId,
                        User = new UserViewModel
                        {
                            Id = s.User.Id,
                            UserName = s.User.UserName
                        }
                    })));

            CreateMap<CommentDataModel, CommentModel>();
            CreateMap<PostViewModel, CommentModel>()
                .ForMember(x => x.User, opt => opt.Ignore());
            CreateMap<CommentModel, CommentDataModel>();
        }
    }
}
