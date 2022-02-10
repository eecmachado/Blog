using Microsoft.AspNetCore.Identity;
using Blog.Infra.EntityFramework.Base.DataModels;
using System;

namespace Blog.Infra.EntityFramework.DataModels
{
    public class CommentDataModel : DataModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public IdentityUser User { get; set; }

        public string UserId { get; set; }

    }
}
