using DapperExampleOgrenci.Models;
using DapperExampleOgrenci.Models.DataVM;
using DapperExampleOgrenci.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperExampleOgrenci.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository repo;
        StudentVM svm = new StudentVM();
        public StudentController(IStudentRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index(StudentVM model)
        {
           
                svm.sList = repo.GetAll(model);
            
            return View(svm);
        }

        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = repo.Find(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Surname,Email,Adress")] Student company)
        {
            if (ModelState.IsValid)
            {
                repo.Add(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = repo.Find(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Surname,Email,Adress")] Student company)
        {
            if (id != company.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repo.Update(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);

        }

        // GET: Companies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            repo.Delete(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }
    }
}
