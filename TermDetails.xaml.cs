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
    public partial class TermDetails : ContentPage
    { 
        int termId;

        public static string TermStart { get; set; }
        public static string TermEnd { get; set; }

        public TermDetails(Terms currTerm)
        {
            InitializeComponent();

            termId = Global.CurrTerm.TermID;
            TermStart = Global.CurrTerm.Start.ToString();
            TermEnd = Global.CurrTerm.End.ToString();

            currTerm = Global.CurrTerm;

            termDetailName.Text = Global.CurrTerm.TermName;
            termDetailStart.Text = TermStart;
            termDetailEnd.Text = TermEnd;




        }
    }
}