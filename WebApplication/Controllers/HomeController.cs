using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator Mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        public IActionResult Index()
        {
            return View(Mediator.Send(new Application.Queries.Products.GetProductsQuery(x => true)).Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
