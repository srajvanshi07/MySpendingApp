using System;
using System.Collections.Generic;
using System.Text;

namespace MySpendingApp.Model
{    public class Budget
    {
        public string Amount { get; set; }
        public string Filename { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
    public enum BudgetCategory
    {
        CarryOver,
        Salary
    };
}
