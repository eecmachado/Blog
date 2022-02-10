using Microsoft.AspNetCore.Mvc;
using Blog.Api.Models;
using Blog.Application.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommentUseCase _commentUseCase;

        public HomeController(ICommentUseCase commentUseCase)
        {
            _commentUseCase = commentUseCase;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _commentUseCase.Get();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier });
        }
    }
}
