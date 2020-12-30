using AmountExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmountExpenses.Data.Repository
{

    public class Repository : IRepository
    {
        private AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            
        }

        public List<Expense> GetAllExpenses()
        {
            if (_context.Expenses.Any())
            {
                return _context.Expenses.ToList();
                
            }
            return new List<Expense>();

        }

        public void Remove(int id)
        {
            _context.Expenses.Remove(GetExpense(id));
        }

        

        public async Task<bool> SaveChangesAsync()
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
            
        }
        public Expense GetExpense(int id)
        {
            return _context.Expenses.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
        }
    }
}
