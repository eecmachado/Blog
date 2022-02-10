using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Interfaces;
using Blog.Application.UseCases.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentUseCase _commentUseCase;
        private readonly IHttpContextAccessor _httpContext;

        public CommentController(ICommentUseCase commentUseCase,
            IHttpContextAccessor httpContext)
        {
            _commentUseCase = commentUseCase;
            _httpContext = httpContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            model.UserId = userId.Value;
            model.Created = System.DateTime.UtcNow;
            await _commentUseCase.Post(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            await _commentUseCase.Edit(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
