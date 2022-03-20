using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Contacts.Classes;
using Xamarin.Essentials;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetails : ContentPage
    {
        public static string coursStart { get; set; }
        public static string coursEnd { get; set; }

        public CourseDetails(Courses CurrCourse)
        {

            coursStart = CurrCourse.StartDate.ToString();
            coursEnd = CurrCourse.EndDate.ToString();

            InitializeComponent();

            Global.CurrCourse = CurrCourse;

            courseName.Text = CurrCourse.CourseName;
            statLabel.Text = CurrCourse.Status.ToString();
            startDateLabel.Text = coursStart;
            endDateLabel.Text = coursEnd;
            editSwitchNot.Text = CurrCourse.NotificationEnabled ? "ON" : "OFF";
            instructorNameLabel.Text = CurrCourse.InstructorName;
            instructorPhoneLabel.Text = CurrCourse.InstructorPhone;
            instructorEmailLabel.Text = CurrCourse.InstructorEmail;
            notesEdit.Text = CurrCourse.Notes;
        }

        private void addAssessment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssessment());
        }

        private void viewAssessment_Clicked(object sender, EventArgs e)
        {
           

            Navigation.PushAsync(new AssessmentList());
        }

        private async void shareNotesButton_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync($"Notes from {courseName.Text}:\n{notesEdit.Text}");
        }

        private void editCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCourse(Global.CurrCourse));
        }

        
    }
}