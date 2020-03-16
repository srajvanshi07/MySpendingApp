using MySpendingApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySpendingApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //private const int V = 1;

        public string Total { get; set; }
        public string Budget { get; set; }
        public string Balance { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }
        // private void BalanceCalulation()
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // set up expense
            var files = Directory.EnumerateFiles(App.Folderpath, "*.expenses.csv");
            Double ExpenseTotal = 0.00;

            // first time run, expense file doesn't exist yet.
            // run foreach loop only when files exist
            if (files == null || !files.Any())
            {
                Total = "0.00";
            }
            else
            {
                foreach (var filename in files)
                {
                    string file = File.ReadAllText(filename);
                    string[] array = file.Split(',');
                    // it has issue
                    ExpenseTotal += double.Parse(array[1]);
                }
                Total = ExpenseTotal.ToString();
            }
            ShowTotal.Text = "$" + Total;
            var filename_budget = Directory.EnumerateFiles(App.Folderpath, "*.MonthlyBudget.csv");
            if (filename_budget == null || !filename_budget.Any())
            {
                Budget = "0.00";
            }
            else
            {
                foreach (var file_budget in filename_budget)
                {
                    Budget = File.ReadAllText(file_budget);
                }
            }
            ShowBudget.Text = "$" + Budget;
            //balance
            double balance = double.Parse(Budget) - double.Parse(Total);

            //format: -$0.00
            if (balance < 0)
            {
                balance = -balance;
                Balance = balance.ToString();
                ShowBalance.Text = "-$" + Balance;
            }
            else if (balance == 0)
            {
                ShowBalance.Text = "$0.00";
            }
            else
            {
                // format: $0.00
                Balance = balance.ToString();
                ShowBalance.Text = "$" + Balance;
            }
        }

        private async void Expense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntry());
        }
        private async void Budget_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BudgetEntry());
        }
        private async void Transaction_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseList());
        }
    }
}
