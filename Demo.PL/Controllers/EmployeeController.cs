using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; // التغيير هنا
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 1. Index (With Search)
        public IActionResult Index(string searchInp)
        {
            var employees = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(searchInp))
                employees = _unitOfWork.EmployeeRepository.GetAll();
            else
                employees = _unitOfWork.EmployeeRepository.GetEmployeesByName(searchInp);

            return View(employees);
        }

        // 2. Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // استخدام UnitOfWork
                _unitOfWork.EmployeeRepository.Add(employee);
                // _unitOfWork.Complete(); // لو الـ Add في الـ GenericRepo بتعمل Save، مش محتاجين دي هنا

                TempData["Message"] = "Employee Created Successfully!!";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // 3. Details
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest();
            var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee is null) return NotFound();

            return View(viewName, employee);
        }

        // 4. Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.EmployeeRepository.Update(employee);
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

        // 5. Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            try
            {
                _unitOfWork.EmployeeRepository.Delete(employee);
                TempData["Message"] = "Employee Deleted Successfully!!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employee);
            }
        }
    }
}