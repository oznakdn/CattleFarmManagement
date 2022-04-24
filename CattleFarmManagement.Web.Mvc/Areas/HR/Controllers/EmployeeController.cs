using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.EmployeeDtos;
using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CattleFarmManagement.Web.Mvc.Controllers
{
   
    [Area("HR")]
    [Authorize(Roles ="HR")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _employeeService.GetAll();
            if(result.Count>0)
            {
                return View(result);

            }
            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult>GetDetail(int Id)
        {
            var result = await _employeeService.GetDetail(Id);
            if(result!=null)
            {
                return View(result);
            }
            return NotFound(TempData["Error"] = "Employee not found!");
        }

        public IActionResult Add()
        {
            return View(new CreateEmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult>Add(CreateEmployeeDto model)
        {
            if(ModelState.IsValid)
            {
                await _employeeService.AddWithContact(model);
                TempData["Info"] = "The employee is added";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Employee not added";
            return View(model);
        }

        public async Task<IActionResult>GetContact(int Id)
        {
            var result =await _employeeService.GetContact(Id);
            if(result!=null)
            {
                return View(result);
            }

            return RedirectToAction(nameof(Add));
        }
    }
}
