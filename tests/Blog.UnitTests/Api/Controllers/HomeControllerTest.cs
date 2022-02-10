using Moq;
using Blog.Api.Controllers;
using Blog.Application.Interfaces;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UnitTests.Api.Controllers
{
    public class HomeControllerTest
    {
        private readonly Mock<ICommentUseCase> _mockCommentUseCase;
        private readonly HomeController _homeController;

        public HomeControllerTest()
        {
            _mockCommentUseCase = new Mock<ICommentUseCase>();
            _homeController = new HomeController(_mockCommentUseCase.Object);
        }

        [Fact]
        public async Task Index_Should_Return_Ok()
        {
            var result = await _homeController.Index();
            _mockCommentUseCase.Verify(v => v.Get(), Times.Once);
            result.Should().BeOfType(typeof(ViewResult));
            result.Should().NotBeNull();
        }

        [Fact]
        public void Error_Should_Return_Ok()
        {
            var result = _homeController.Error();
            result.Should().BeOfType(typeof(ViewResult));
            result.Should().NotBeNull();
        }
    }
}
