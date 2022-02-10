using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.Infra.EntityFramework.DataModels;

namespace Blog.Infra.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CommentDataModel> CommentData { get; set; }
    }
}
