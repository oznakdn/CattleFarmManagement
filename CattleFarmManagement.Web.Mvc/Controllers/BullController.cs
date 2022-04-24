using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.BullDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{
   
    [Authorize(Roles ="Admin")]
    public class BullController : Controller
    {
        private readonly IBullService _bullService;

        public BullController(IBullService bullService)
        {
            _bullService = bullService;
        }

        public async Task <IActionResult> Index()
        {
            var result = await _bullService.GetAll();
            if(result.Count>0)
            {
                return View(result);

            }

            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult>GetDetail(int Id)
        {
            var result = await _bullService.GetWithPictures(Id);
            if(result!=null)
            {
                return View(result);
            }

            return NotFound(TempData["Error"] = "The bull not found");
            
        }

        public IActionResult Add()
        {
            return View(new CreateBullDto());
        }

        [HttpPost]
        public async Task<IActionResult>Add(CreateBullDto createBullDto)
        {
            if(ModelState.IsValid)
            {
                await _bullService.Add(createBullDto);
                TempData["Info"] = $"{createBullDto.TagNumber} Tag Number's bull is added";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Bull not added!";
            return View(createBullDto);
        }

        public async Task<IActionResult>Update(int Id)
        {
            var bull = await _bullService.Get(x => x.ID == Id);
            var model = new UpdateBullDto
            {
                Name=bull.Name,
                TagNumber=bull.TagNumber,
                Age=bull.Age,
                Weight=bull.Weight,
                Description=bull.Description
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBullDto model)
        {
            
            if(ModelState.IsValid)
            {
                await _bullService.Update(model);
                TempData["Info"] = $"{model.TagNumber} Tag Number's bull is updated";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Bull not updated";
            return View(model);
        }


    }
}
