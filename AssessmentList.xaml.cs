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
    public partial class AssessmentList : ContentPage
    {
        int courseId = Global.CurrCourse.CourseID;


        public AssessmentList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                //conn.CreateTable<Assessment>();
                //var assessments = conn.Table<Assessment>().ToList();

                //assessmentLV.ItemsSource = assessments;

                conn.CreateTable<Assessment>();
                var assessments = conn.Query<Assessment>("SELECT * FROM Assessment WHERE CourseID = '" + courseId + "';");
                assessmentLV.ItemsSource = assessments;
            }
        }

        private void assessmentListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private void assessmentListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private void DeleteAssess_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {

                con.CreateTable<Assessment>();
                int rows = con.Delete(Global.CurrAsses);

            }
            Navigation.PushAsync(new AssessmentList());
        }

        private void DetailsAssess_Clicked(object sender, EventArgs e)
        {

            if (Global.CurrAsses == null)
            {
                DisplayAlert("Alert", "Please select an assessment", "Ok");
            }
            else { Navigation.PushAsync(new AssessmentDetails(Global.CurrAsses)); }

        }

        private void assessmentLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Global.CurrAsses = assessmentLV.SelectedItem as Assessment;
        }

        private void addAssess_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssessment());
        }

        private void editAsses_Clicked(object sender, EventArgs e)
        {

            if(Global.CurrAsses == null)
            {
                DisplayAlert("Alert", "Please select an assessment", "Ok");
            }
            else { Navigation.PushAsync(new EditAssessment(Global.CurrAsses)); }
            
        }


       



        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}