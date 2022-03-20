using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Contacts.Classes;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;



namespace Contacts
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();

           
        }

        private void ADDTERM_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTerm());
        }

        private void EDITTERM_Clicked(object sender, EventArgs e)
        {

            if (Global.CurrTerm == null)
            {
                DisplayAlert("Alert", "Please select term", "Ok");
            }
            else { Navigation.PushAsync(new ModifyTerms(Global.CurrTerm)); }
           
            
        }

        private void DELETETERM_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
              
                    //con.CreateTable<Terms>();
                    int rows = con.Delete(Global.CurrTerm);
                   
            }
            Navigation.PushAsync(new MainPage());
        }

        private void VIEWCOURSES_Clicked(object sender, EventArgs e)
        {
        

            if (Global.CurrTerm == null)
            {
                DisplayAlert("Alert", "Please select term before moving forward", "Ok");
            }
            else { Navigation.PushAsync(new CourseView()); }



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Terms>();
                var terms = conn.Table<Terms>().ToList();

                termListView.ItemsSource = terms;


                //Course Notifications
                var courseList = conn.Query<Courses>("SELECT * from Courses Where NotificationEnabled = true;").ToList();

                for (int i = 0; i < courseList.Count; i++)
                {
                    if (courseList[i].StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Alert", " You have a course that is starting today!", 101);
                    }
                    if (courseList[i].EndDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Reminder", "You have a course that is ending today!", 102);
                    }
                }

                //Assessment Notifications
                var assessmentList = conn.Query<Assessment>("SELECT * from Assessment Where NotificationEnabled = true;").ToList();

                for (int i = 0; i < assessmentList.Count; i++)
                {
                    if (assessmentList[i].Start == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Alert", "You have an assessment that is starting today!", 103);
                    }
                    if (assessmentList[i].End == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Reminder", "You have an assessment that is due today!", 104);
                    }
                }



            }

           
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
          //
        }

        private void termsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Global.CurrTerm = termListView.SelectedItem as Terms;
        }

        private void DETAILS_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermDetails(Global.CurrTerm));
        }
    }
}
