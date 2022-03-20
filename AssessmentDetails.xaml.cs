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
    public partial class AssessmentDetails : ContentPage
    {
        public static string assessStart { get; set; }
        public static string assessEnd { get; set; }


        public AssessmentDetails(Assessment CurrAsses)
        {
            assessStart = Global.CurrAsses.Start.ToString();
            assessEnd = Global.CurrAsses.End.ToString();

            InitializeComponent();

            CurrAsses = Global.CurrAsses;

            assessName.Text = Global.CurrAsses.Name;
            assessStatus.Text = Global.CurrAsses.Type.ToString();
            startDateLabel.Text = assessStart;
            endDateLabel.Text = assessEnd;
            notifEnabled.Text = Global.CurrAsses.NotificationEnabled ? "ON" : "OFF";

        }

    }
}