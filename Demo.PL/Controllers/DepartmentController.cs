using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo) => _repo = repo;

        public IActionResult Index() => View(_repo.GetAll());

        [HttpGet] public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) { _repo.Add(department); return RedirectToAction(nameof(Index)); }
            return View(department);
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue) return BadRequest();
            var dept = _repo.Get(id.Value);
            if (dept == null) return NotFound();
            return View(viewName, dept);
        }

        [HttpGet] public IActionResult Edit(int? id) => Details(id, "Edit");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            if (ModelState.IsValid) { _repo.Update(department); return RedirectToAction(nameof(Index)); }
            return View(department);
        }

        [HttpGet] public IActionResult Delete(int? id) => Details(id, "Delete");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            _repo.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}