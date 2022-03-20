using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Classes;
using SQLite;
using System.Text.RegularExpressions;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCourse : ContentPage
    {
        public static DateTime courseStart { get; set; }
        public static DateTime courseEnd { get; set; }



        public EditCourse(Courses CurrCourse)
        {
            InitializeComponent();

            Global.CurrCourse = CurrCourse;

            CourseEditName.Text = CurrCourse.CourseName;
            courseStatEditPicker.SelectedItem = CurrCourse.Status.ToString();
            courseEditStartDate.Date = Convert.ToDateTime(CurrCourse.StartDate);
            courseEditEndDate.Date = Convert.ToDateTime(CurrCourse.EndDate);
            editSwitchNot.IsToggled = CurrCourse.NotificationEnabled;
            CourseEditInst.Text = CurrCourse.InstructorName;
            courseEditPhone.Text = CurrCourse.InstructorPhone;
            courseEditEmail.Text = CurrCourse.InstructorEmail;
            editNotes.Text = CurrCourse.Notes;
        }

        private void courseEditStartDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Global.CurrCourse.StartDate = e.NewDate;
        }

        private void courseEditEndDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Global.CurrCourse.EndDate = e.NewDate;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {

            if (courseStart > courseEnd)
            {
                DisplayAlert("Error.", "Please verify that start date is before the end date.", "Ok");
                return;
            }

            if (String.IsNullOrEmpty(CourseEditName.Text))
            {
                DisplayAlert("Alert", "Please enter a course name", "Ok");
                return;
            }

            if (CourseEditName.Text == null || CourseEditName.Text == "")
            {
                DisplayAlert("Error.", "Please enter a course game", "Ok");
                return;
            }

            if (courseStatEditPicker.SelectedItem == null)
            {
                DisplayAlert("Error", "Please choose a course status", "Ok");
                return;
            }

            if (CourseEditInst.Text == null || CourseEditInst.Text == "" ||
                courseEditPhone.Text == null || courseEditPhone.Text == "" ||
                courseEditEmail.Text == null || courseEditEmail.Text == "")
            {
                DisplayAlert("Error", "Please provide all of the course instructor's info - Name, Phone, Email", "Ok");
                return;
            }

           
            if(courseEditEmail.Text != "")
            {
                string email = courseEditEmail.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    Global.CurrCourse.CourseName = CourseEditName.Text;
                    Global.CurrCourse.Status = courseStatEditPicker.SelectedItem.ToString();
                    Global.CurrCourse.StartDate = courseEditStartDate.Date;
                    Global.CurrCourse.EndDate = courseEditEndDate.Date;
                    Global.CurrCourse.InstructorName = CourseEditInst.Text;
                    Global.CurrCourse.InstructorPhone = courseEditPhone.Text;
                    Global.CurrCourse.InstructorEmail = courseEditEmail.Text;
                    Global.CurrCourse.NotificationEnabled = editSwitchNot.IsToggled;
                    Global.CurrCourse.Notes = editNotes.Text;

                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Courses>();

                        int rowsAdded = conn.Update(Global.CurrCourse);    
                    }
                    Navigation.PushAsync(new CourseView());
                }

                else
                {
                    DisplayAlert("alert", email + " is not a Valid Email Address", "ok");
                }
            }
           
        }
    }
}