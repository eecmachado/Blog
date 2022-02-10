using Blog.Domain.Base.Models;
using System;

namespace Blog.Domain.DomainModels
{
    public class CommentModel : DomainModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public UserModel User { get; set; }
    }
}
