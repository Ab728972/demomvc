using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.Helpers;
using Demo.PL.ViewModels; // تأكد من الـ using ده
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 1. Index (Async)
        public async Task<IActionResult> Index(string searchInp)
        {
            var employees = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(searchInp))
                employees = await _unitOfWork.EmployeeRepository.GetAllAsync(); // استخدام النسخة الـ Async
            else
                employees = _unitOfWork.EmployeeRepository.GetEmployeesByName(searchInp); // دي لسه Sync عادي

            return View(_mapper.Map<IEnumerable<EmployeeViewModel>>(employees));
        }

        // 2. Create (With Image Upload)
        [HttpGet]
        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                // Upload Image
                if (employeeVM.Image is not null)
                {
                    employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "images");
                }

                var employee = _mapper.Map<Employee>(employeeVM);

                await _unitOfWork.EmployeeRepository.AddAsync(employee);
                // _unitOfWork.Complete(); // لو AddAsync بتعمل Save

                TempData["Message"] = "Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

    }
}