using System;
using System.Collections.Generic;
using System.Text;

namespace MySpendingApp.Model
{
    public class Expense
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public string CategoryIconPAth { get; set; }
    }
    public enum ExpenseCategory
    {
        Home,
        Groceries,
        Entertainment,
        Food,
        Charity,
        Utilities,
        Auto,
        Education,
        HealthAndWellness,
        Shopping,
        Medical,
        DayCare,
        Other,
        Saving
    };
}