using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.UseCases.ViewModels;
using Blog.Domain.DomainModels;
using Blog.Domain.Interface;
using System.Threading.Tasks;

namespace Blog.Application.UseCases
{
    public class CommentUseCase : ICommentUseCase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentUseCase(ICommentRepository commentRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentViewModel> Get()
        {
            var model = await _commentRepository.Get();
            return _mapper.Map<CommentViewModel>(model);
        }

        public async Task Post(PostViewModel viewModel)
        {
            var model = _mapper.Map<CommentModel>(viewModel);
            await _commentRepository.Insert(model);
        }

        public async Task Edit(PostViewModel viewModel)
        {
            var model = _mapper.Map<CommentModel>(viewModel);
            await _commentRepository.Update(model);
        }
    }
}
