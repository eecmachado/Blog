using AutoMapper;
using Moq;
using Blog.Application.UseCases;
using Blog.Application.UseCases.ViewModels;
using Blog.Domain.DomainModels;
using Blog.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Blog.UnitTests.Application.UseCases
{
    public class CommentUseCaseTest
    {
        private readonly Mock<ICommentRepository> _mockCommentRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CommentUseCase _commentUseCase;

        public CommentUseCaseTest()
        {
            _mockCommentRepository = new Mock<ICommentRepository>();
            _mockMapper = new Mock<IMapper>();
            _commentUseCase = new CommentUseCase(_mockCommentRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Get_Should_Return_With_Value()
        {
            var models = new List<CommentModel>();
            var viewModel = new CommentViewModel();

            _mockCommentRepository.Setup(s => s.Get()).ReturnsAsync(models);
            _mockMapper.Setup(s=>s.Map<CommentViewModel>(models)).Returns(viewModel);
            var result = await _commentUseCase.Get();

            result.Should().NotBeNull();
            result.Should().Be(viewModel);
        }

        [Fact]
        public async Task Get_Should_Return_Without_Value()
        {
            List<CommentModel> models = null;
            CommentViewModel viewModel = null;

            _mockCommentRepository.Setup(s => s.Get()).ReturnsAsync(models);
            _mockMapper.Setup(s => s.Map<CommentViewModel>(models)).Returns(viewModel);
            var result = await _commentUseCase.Get();

            result.Should().BeNull();
        }

        private PostViewModel Setup()
        {
            var model = new CommentModel();
            var viewModel = new PostViewModel();

            _mockMapper.Setup(s => s.Map<CommentModel>(viewModel)).Returns(model);

            return viewModel;
        }

        [Fact]
        public async Task Post_Should_Save()
        {
            var viewModel = Setup();

            await _commentUseCase.Post(viewModel);

            _mockCommentRepository.Verify(v => v.Insert(It.IsAny<CommentModel>()), Times.Once);
        }

        [Fact]
        public async Task Edit_Should_Save()
        {
            var viewModel = Setup();

            await _commentUseCase.Edit(viewModel);

            _mockCommentRepository.Verify(v => v.Update(It.IsAny<CommentModel>()), Times.Once);
        }
    }
}
