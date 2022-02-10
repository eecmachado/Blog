using Blog.Domain.Base.Interfaces.Repositories;
using Blog.Domain.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain.Interface
{
    public interface ICommentRepository: IRepository<CommentModel>
    {
        Task<IEnumerable<CommentModel>> Get();
    }
}
