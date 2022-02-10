using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Blog.Application.UseCases.ViewModels;
using Blog.Domain.DomainModels;

namespace Blog.Infra.CrossCutting.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser, UserModel>();
            CreateMap<UserModel, UserViewModel>();
        }
    }
}
