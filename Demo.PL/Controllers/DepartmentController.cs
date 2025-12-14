using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentController(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo; // Õﬁ‰ «· »⁄Ì… (Dependency Injection)
        }

        // 1. Index (⁄—÷ ﬂ· «·√ﬁ”«„)
        public IActionResult Index()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }

        // 2. Create (› Õ ’›Õ… «·≈÷«›…)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 2. Create ( ‰›Ì– «·≈÷«›…)
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // «· Õﬁﬁ „‰ «·œ« « (Name, Code required)
            {
                _departmentRepo.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // 3. Details ( ›«’Ì· ﬁ”„ „⁄Ì‰)
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest(); // 400

            var department = _departmentRepo.Get(id.Value);
            if (department is null) return NotFound(); // 404

            return View(viewName, department);
        }

        // 4. Edit (› Õ ’›Õ… «· ⁄œÌ·)
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // »‰” Œœ„ ‰›” ·ÊÃÌﬂ «·‹ Details ⁄‘«‰ ‰ÃÌ» «·ﬁ”„
            return Details(id, "Edit");
        }

        // 4. Edit ( ‰›Ì– «· ⁄œÌ·)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepo.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log Exception
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }

        // 5. Delete (› Õ ’›Õ… «·Õ–›)
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        // 5. Delete ( ‰›Ì– «·Õ–›)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            try
            {
                _departmentRepo.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }
        }
    }
}