using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult Index() => View(_repo.GetAll());

        [HttpGet] public IActionResult Create() => View();

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(employee); 

                    
                    TempData["Message"] = "Employee Updated Successfully!!";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employee);
        }
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(employee);
                TempData["Message"] = "Employee Created Successfully!!"; 
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        
    }
}