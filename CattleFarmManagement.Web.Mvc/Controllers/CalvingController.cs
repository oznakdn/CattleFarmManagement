using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.CalvingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{

    [Authorize(Roles ="Admin")]
    public class CalvingController : Controller
    {
        private readonly ICalvingService _calvingService;
        private readonly IBullService _bullService;

        public CalvingController(ICalvingService calvingService, IBullService bullService)
        {
            _calvingService = calvingService;
            _bullService = bullService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var calvings = await _calvingService.GetAll(Id);
            ViewData["cowId"] = Id;
            if(calvings.Count>0)
            {
                return View(calvings);

            }

            return RedirectToAction(nameof(Add), new { Id = ViewData["cowId"] });
        }

        public async Task<IActionResult> Add(int Id)
        {
            ViewBag.bullId =await _bullService.GetAll();
            return View(new CreateCalvingDto { CowId=Id});
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCalvingDto model)
        {
            if(ModelState.IsValid)
            {
                await _calvingService.Add(model);
                TempData["Info"] = "The Cow's calving is added";
                return RedirectToAction(nameof(Index), new { Id = model.CowId });
            }

            ViewBag.bullId = await _bullService.GetAll();
            TempData["Error"] = "Calving not added!";
            return View(model);
        }


    }
}
