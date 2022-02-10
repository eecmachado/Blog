using Blog.Domain.Base.Models;

namespace Blog.Domain.DomainModels
{
    public class UserModel : DomainModel<string>
    {
        public string UserName { get; set; }
    }
}
