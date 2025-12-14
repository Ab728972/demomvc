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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) { _repo.Add(employee); return RedirectToAction(nameof(Index)); }
            return View(employee);
        }
        // باقي الدوال (Details, Edit, Delete) انسخها من Department وغير الاسم بس
    }
}