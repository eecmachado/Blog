using Next.Blog.Infra.Data.Base.DataModels;
using System;

namespace Next.Blog.Infra.Data.DataModels
{
    public class CommentDataModel : DataModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public IdentityUser

        public string UserId { get; set; }

    }
}
