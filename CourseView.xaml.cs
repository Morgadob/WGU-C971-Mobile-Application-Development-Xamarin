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
    public partial class CourseView : ContentPage
    {
        int termId = Global.CurrTerm.TermID;

        public CourseView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {

                conn.CreateTable<Courses>();
                var forTerm = conn.Query<Courses>("SELECT * FROM Courses WHERE TermID = '" + termId  + "';");

                //var forTerm = conn.Query<Courses>("SELECT * FROM Courses;");

                courseListView.ItemsSource = forTerm;
            }
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCourse());
        }

        private void EditCourse_Clicked(object sender, EventArgs e)
        {
            if (Global.CurrCourse == null)
            {

                DisplayAlert("Alert", "Please select a Course in order to edit the details", "OK");
                Navigation.PushAsync(new CourseView());

            }
            else
            {

                Navigation.PushAsync(new EditCourse(Global.CurrCourse));
            }
        }

        private void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
              
                con.CreateTable<Courses>();
                int rows = con.Delete(Global.CurrCourse);

            }
            Navigation.PushAsync(new CourseView());
        }

        private void CourseDetails_Clicked(object sender, EventArgs e)
        {
            if (Global.CurrCourse == null)
            {
                DisplayAlert("Alert", "Please select a Course in order to view the details", "Ok");
            }
            else { Navigation.PushAsync(new CourseDetails(Global.CurrCourse)); }

        }

        private void courseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Global.CurrCourse = courseListView.SelectedItem as Courses;
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}