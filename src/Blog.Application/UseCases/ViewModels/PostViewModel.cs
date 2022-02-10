using System;

namespace Blog.Application.UseCases.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}
