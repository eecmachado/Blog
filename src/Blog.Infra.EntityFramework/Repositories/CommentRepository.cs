using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.DomainModels;
using Blog.Domain.Interface;
using Blog.Infra.EntityFramework.Base;
using Blog.Infra.EntityFramework.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Infra.EntityFramework.Repositories
{
    public class CommentRepository : Repository<ApplicationDbContext, CommentModel, CommentDataModel>, ICommentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CommentRepository(ApplicationDbContext contextFactory, IMapper mapper)
            : base(contextFactory, mapper)
        {
            _applicationDbContext = contextFactory;
        }

        public async Task<IEnumerable<CommentModel>> Get()
        {
            var dataModel = await _applicationDbContext.CommentData
                .Include(i => i.User)
                .ToListAsync();

            var model = Mapper.Map<IEnumerable<CommentModel>>(dataModel);

            return model;
        }
    }
}
