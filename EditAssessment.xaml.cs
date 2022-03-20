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
    public partial class EditAssessment : ContentPage
    {

        public static DateTime assessStart { get; set; }
        public static DateTime assessEnd { get; set; }

        public EditAssessment(Assessment CurrAsses)
        {
            InitializeComponent();

            assessName.Text = Global.CurrAsses.Name;
            pickerAssessEdit.SelectedItem = Global.CurrAsses.Type.ToString();
            assessStartDatePicker.Date = Global.CurrAsses.Start;
            assessEndDatePicker.Date = Global.CurrAsses.End;

        }

        private void pickerAssessEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void assessStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Global.CurrAsses.Start = e.NewDate;
        }

        private void assessEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Global.CurrAsses.End = e.NewDate;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(assessName.Text))
            {
                DisplayAlert("Alert", "Please fill in the assessment name", "Ok");
                return;
            }

            if (assessStart > assessEnd)
            {
                DisplayAlert("Alert", "The start date of the assessment must be before the end date", "Ok");
                return;
            }

            if (pickerAssessEdit == null)
            {
                DisplayAlert("Alert", "Please select an assessment type", "Ok");
                return;
            }



            if (Global.CurrAsses.Start > Global.CurrAsses.End)
            {
                DisplayAlert("Alert", "The start date of the assessment must be before the end date", "Ok");
                return;
            }
            else
            {
             

                Global.CurrAsses.Name = assessName.Text;
                Global.CurrAsses.Type = pickerAssessEdit.SelectedItem.ToString();
                Global.CurrAsses.Start = assessStartDatePicker.Date;
                Global.CurrAsses.End = assessEndDatePicker.Date;

                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    con.CreateTable<Assessment>();
                    int rowsAdded = con.Update(Global.CurrAsses);

                    if (rowsAdded >= 1)
                    {
                        DisplayAlert("Alert", "Assessment successfully added", "Ok");
                    }
                }

                Navigation.PushAsync(new AssessmentList());

            }

          

        }
    }
}