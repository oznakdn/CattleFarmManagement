using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.CowDtos;
using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{

    [Authorize(Roles ="Admin")]
    public class CowController : Controller
    {
        private readonly ICowService _cowService;
        private readonly IWebHostEnvironment _env;

        public CowController(ICowService cowService, IWebHostEnvironment env)
        {
            _cowService = cowService;
            _env = env;
        }



        public IActionResult Index()
        {
            var result = _cowService.GetAll();
            if(result.Count>0)
            {
                return View(result);

            }

            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> GetDetail(int Id)
        {
            try
            {
                var result = await _cowService.GetById(Id);
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Add()
        {
            return View(new CreateCowDto());

        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateCowDto createCowDto)
        {
            if (ModelState.IsValid)
            {
                await _cowService.Add(createCowDto);
                TempData["Info"] = "The cow is added";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Cow not added";
            return View(createCowDto);


        }
        public async Task<IActionResult> Update(int Id)
        {
            var cow =await _cowService.Get(x => x.ID == Id);
            var model = new UpdateCowDto
            {
               Name=cow.Name,
               TagNumber=cow.TagNumber,
               Age=cow.Age,
               Weight=cow.Weight,
               Description=cow.Description,
               IsActive=cow.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCowDto model)
        {
           
            if(ModelState.IsValid)
            {
                await _cowService.Update(model);
                TempData["Info"] = $"{model.TagNumber} Tag Number's cow is updated";
                return RedirectToAction(nameof(GetDetail),new {Id=model.ID});
            }

            return View(model);
        }
    }
}
