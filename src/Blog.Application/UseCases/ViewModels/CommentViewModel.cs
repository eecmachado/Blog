using System.Collections.Generic;

namespace Blog.Application.UseCases.ViewModels
{
    public class CommentViewModel : PostViewModel
    {
        public List<PostViewModel> Posts { get; set; }
    }
}
