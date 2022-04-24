using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.MilkRecordDtos;
using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{

    [Authorize(Roles = "Admin")]
    public class MilkRecordController : Controller
    {
        private readonly IMilkRecordService _milkRecordService;

        public MilkRecordController(IMilkRecordService milkRecordService)
        {
            _milkRecordService = milkRecordService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var result =await _milkRecordService.GetAll(Id);
            TempData["cowId"] = Id; //Index.cshtml de asp-route-id="@ViewBag.Id" göndermek için
            if (result.Count>0)
            {
                ViewBag.average = _milkRecordService.Average(Id);
                return View(result);
            }
            else
            {
                return RedirectToAction(nameof(Add),"MilkRecord",new {Id});
            }
            
        }

        public IActionResult Add(int Id)
        {
            return View(new CreateMilkRecordDto { CowId=Id});
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMilkRecordDto createMilkRecordDto)
        {

            if (ModelState.IsValid)
            {
                await _milkRecordService.Add(createMilkRecordDto);
                return RedirectToAction(nameof(Index),"MilkRecord",new {Id=createMilkRecordDto.CowId});
            }
            return View(createMilkRecordDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            var record =await _milkRecordService.GetById(Id);
            var model = new UpdateMilkRecordDto
            {
                RecordNumber = record.RecordNumber,
                RecordDate=record.RecordDate,
                Quantity=record.Quantity,
                Description=record.Description,
                CowId=record.CowId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Update(UpdateMilkRecordDto updateMilkRecordDto)
        {
            if(ModelState.IsValid)
            {
                await _milkRecordService.Update(updateMilkRecordDto);
                return RedirectToAction(nameof(Index), new { Id = updateMilkRecordDto.CowId });
            }

            return View(updateMilkRecordDto);
        }


        public async Task<IActionResult>Delete(int Id)
        {
            await _milkRecordService.Delete(Id);
            return RedirectToAction(nameof(Index),new { Id=TempData["cowId"]});
        }
    }
}
