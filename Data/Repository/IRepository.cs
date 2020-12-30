using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmountExpenses.Models;

namespace AmountExpenses.Data.Repository
{
    public interface IRepository
    {
        public void Add(Expense expense);
        public List<Expense> GetAllExpenses();
        public void Update(Expense expense);
        public void Remove(int id);
        Expense GetExpense(int id);
        Task<bool> SaveChangesAsync();


    }
}
