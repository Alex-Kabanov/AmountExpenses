using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmountExpenses.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AmountExpenses.Data;
using AmountExpenses.Data.Repository;


namespace AmountExpenses.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        public HomeController(IRepository repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            var posts = _repo.GetAllExpenses();
            return View(posts);
        }
        public IActionResult Post(int id)
        {
            var post = _repo.GetExpense(id);
            return View(post);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Expense());
            }
            else
            {
                var post = _repo.GetExpense((int)id);
                return View(post);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (expense.Id > 0)
                _repo.Update(expense); 
            else
                _repo.Add(expense);
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(expense);
        }
        public IActionResult Show()
        {
            if (_repo.GetAllExpenses().Any())
            {
                return View(_repo.GetAllExpenses());
                
            }
            return View("Index");

        }
        public async Task <IActionResult> Remove(int id)
        {
            _repo.Remove(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
