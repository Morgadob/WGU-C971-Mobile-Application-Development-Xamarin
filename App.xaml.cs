using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Contacts.Classes;

namespace Contacts
{
    public partial class App : Application
    {

        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            FilePath = filePath;
        }

       
        

        protected override void OnStart()
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.DropTable<Terms>();
                con.DropTable<Courses>();
                con.DropTable<Assessment>();


                con.CreateTable<Terms>();
                con.CreateTable<Courses>();
                con.CreateTable<Assessment>();
            };



            Global.AddTermData();
            Global.AddCourseData();
            Global.AddAssessmentData();

           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 



    }
}
