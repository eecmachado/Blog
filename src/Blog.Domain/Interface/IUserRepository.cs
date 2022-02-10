using Blog.Domain.Base.Interfaces.Repositories;
using Blog.Domain.DomainModels;
using System.Threading.Tasks;

namespace Blog.Domain.Interface
{
    public interface IUserRepository : IRepository<UserModel, string>
    {
        Task<bool> Login(string email, string password, bool rememberMe);
    }
}
