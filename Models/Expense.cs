using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AmountExpenses.Models
{
    public class Expense
    {
        
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public Categories Categories { get; set; } = Categories.Other;
        public float Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Month { get; set; } = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

        
        
        
        //private int _month;
        //public int Month
        //{
        //    get { return _month; }
        //    set
        //    {
        //        if((value > 0 )&&(value < 13))
        //        {
        //            _month = value;
        //        }
        //    }
        //}
        
    }
}
