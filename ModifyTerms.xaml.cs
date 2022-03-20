using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Contacts.Classes;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyTerms : ContentPage
    {

        public static DateTime termStart { get; set; }
        public static DateTime termEnd { get; set; }


        public ModifyTerms(Terms selectedTerm)
        {
            InitializeComponent();

            Global.CurrTerm = selectedTerm;

            editTermName.Text = selectedTerm.TermName;
            startDate.Date = Convert.ToDateTime(selectedTerm.Start);
            endDate.Date = Convert.ToDateTime(selectedTerm.End);
        }

        private void eTermStartPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            termStart = e.NewDate;

        }

        private void ETermEndPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            termEnd = e.NewDate;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Global.CurrTerm.TermName = editTermName.Text;
            Global.CurrTerm.Start = Convert.ToDateTime(termStart);
            Global.CurrTerm.End = Convert.ToDateTime(termEnd);

            if (String.IsNullOrEmpty(editTermName.Text))
            {
                DisplayAlert("Alert", "Please fill in term name", "Ok");
                return;
            }

            if (termStart > termEnd)
            {
                DisplayAlert("Error.", "Please verify that start date is before the end date.", "Ok");
                return;
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Terms>();
                    int rowsAdded = conn.Update(Global.CurrTerm);
                }

                Navigation.PushAsync(new MainPage());
            }
        }
    }
}