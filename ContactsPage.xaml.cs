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
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        private void newContactToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();

                contactsListView.ItemsSource = contacts;

            }
        }

    }
}