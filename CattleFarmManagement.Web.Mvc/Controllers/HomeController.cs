using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CattleFarmManagement.Web.Mvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICowService _cowService;
        private readonly IBullService _bullService;


        public HomeController(ILogger<HomeController> logger, ICowService cowService, IBullService bullService)
        {
            _logger = logger;
            _cowService = cowService;
            _bullService = bullService;
        }

        public IActionResult Index()
        {
            var cowCount = _cowService.Count();
            var bullCount = _bullService.Count();
            var totalCount = cowCount + bullCount;

            ViewBag.cow = cowCount;
            ViewBag.bull = bullCount;
            ViewBag.total = totalCount;
            return View();
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