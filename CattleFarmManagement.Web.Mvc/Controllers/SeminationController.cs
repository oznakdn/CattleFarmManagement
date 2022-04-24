using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.SeminationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{

    [Authorize(Roles = "Admin")]
    public class SeminationController : Controller
    {
        private readonly ISeminationService _seminationService;
        private readonly IBullService _bullService;
        private readonly IEmployeeService _employeeService;

        public SeminationController(ISeminationService seminationService, IBullService bullService, IEmployeeService employeeService)
        {
            _seminationService = seminationService;
            _bullService = bullService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var result = await _seminationService.GetAll(Id);
            ViewData["cowId"] = Id;
            if(result.Count>0)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction(nameof(Add), new { Id = ViewData["cowId"] });
            }
        }

        public async Task<IActionResult> Add(int Id)
        {
            ViewBag.bullId = await _bullService.GetAll();
            ViewBag.employeeId = await _employeeService.GetAll();
            return View(new CreateSeminationDto { CowId = Id });
        }

        [HttpPost]
        public async Task<IActionResult>Add(CreateSeminationDto createSeminationDto)
        {
            if(ModelState.IsValid)
            {
                await _seminationService.Add(createSeminationDto);
                return RedirectToAction(nameof(Index), new { Id = createSeminationDto.CowId });
            }

            ViewBag.employeeId = await _employeeService.GetAll();
            ViewBag.bullId = await _bullService.GetAll();
            return View(createSeminationDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            var semination = await _seminationService.Get(Id);
            var model = new UpdateSeminationDto
            {
                SeminationNumber=semination.SeminationNumber,
                SeminationDate=semination.SeminationDate,
                BullId=semination.BullId,
                SpermNumber=semination.SpermNumber,
                EmployeeId=semination.EmployeeId,
                ControlDate=semination.ControlDate,
                IsGravid=semination.IsGravid,
                Description=semination.Description,
                CowId=semination.CowId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Update(UpdateSeminationDto updateSeminationDto)
        {
            if(ModelState.IsValid)
            {
                await _seminationService.Update(updateSeminationDto);
                TempData["Info"] = $"{updateSeminationDto.SeminationNumber} number semination is updated";
                return RedirectToAction(nameof(Index), new { Id = updateSeminationDto.CowId });
            }
            TempData["Error"] = "Not Updated";
            return View(updateSeminationDto);
        }
    }
}
