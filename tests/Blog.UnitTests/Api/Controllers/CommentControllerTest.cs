using Microsoft.AspNetCore.Http;
using Moq;
using Blog.Api.Controllers;
using Blog.Application.Interfaces;
using Blog.Application.UseCases.ViewModels;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.UnitTests.Api.Controllers
{
    public class CommentControllerTest
    {
        private readonly Mock<ICommentUseCase> _mockCommentUseCase;
        private readonly Mock<IHttpContextAccessor> _mockHttpContext;
        private readonly CommentController _commentController;

        public CommentControllerTest()
        {
            _mockCommentUseCase = new Mock<ICommentUseCase>();
            _mockHttpContext = new Mock<IHttpContextAccessor>();
            _commentController = new CommentController(_mockCommentUseCase.Object, _mockHttpContext.Object);
        }

        [Fact]
        public async Task Create_Should_Return_Ok()
        {
            var claim = new Claim("", "");

            _mockHttpContext
                .Setup(s => s.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier))
                .Returns(claim);


            var result = await _commentController.Create(new PostViewModel());
            _mockCommentUseCase.Verify(v => v.Post(It.IsAny<PostViewModel>()), Times.Once);
            result.Should().BeOfType(typeof(RedirectToActionResult));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Edit_Should_Return_Ok()
        {
            var result = await _commentController.Edit(It.IsAny<PostViewModel>());
            _mockCommentUseCase.Verify(v => v.Edit(It.IsAny<PostViewModel>()), Times.Once);
            result.Should().BeOfType(typeof(RedirectToActionResult));
            result.Should().NotBeNull();
        }
    }
}
