﻿using MySpendingApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySpendingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetEntry : ContentPage
    {
        private string filename;
        public BudgetEntry()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget budget = new Budget();
            if (string.IsNullOrWhiteSpace(budget.Filename))
            {
                filename = Path.Combine(App.Folderpath,
                    $"{Path.GetRandomFileName()}.MonthlyBudget.csv");

                budget.Filename = filename;
                budget.Amount = editor.Text;

                File.WriteAllText(filename, editor.Text);
            }
            else
            {
                budget.Amount = editor.Text;
                File.WriteAllText(budget.Filename, editor.Text);
            }
            await Navigation.PushAsync(new ExpenseList());
        }
        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            editor.Text = string.Empty;
        }
    }
}