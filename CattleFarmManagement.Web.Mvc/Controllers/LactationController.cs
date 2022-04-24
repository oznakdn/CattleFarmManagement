using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.LactationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{
    [Authorize(Roles ="Admin")]
    public class LactationController : Controller
    {
        private readonly ILactationService _lactationService;

        public LactationController(ILactationService lactationService)
        {
            _lactationService = lactationService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var result = await _lactationService.GetAll(Id);
            ViewBag.cowId = Id;
            if(result.Count>0)
            {
                return View(result);

            }
            return RedirectToAction(nameof(Add), new { Id=ViewBag.cowId });
        }

        public IActionResult Add(int Id)
        {
            return View(new CreateLactationDto { CowId=Id});
        }

        [HttpPost]
        public async Task<IActionResult>Add(CreateLactationDto createLactationDto)
        {
            if(ModelState.IsValid)
            {
                await _lactationService.Add(createLactationDto);
                TempData["Info"] = "The cow's lactation is added";
                return RedirectToAction(nameof(Index), new { Id = createLactationDto.CowId });

            }
            TempData["Error"] = "No Added!";
            return View(createLactationDto);
        }
    }
}
