using Blog.Application.UseCases.ViewModels;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICommentUseCase
    {
        Task<CommentViewModel> Get();

        Task Post(PostViewModel viewModel);

        Task Edit(PostViewModel viewModel);
    }
}
