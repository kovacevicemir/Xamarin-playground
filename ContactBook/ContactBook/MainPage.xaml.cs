using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class MainPage : ContentPage
    {
        public List<Contact> Contacts { get; private set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Contacts = new List<Contact>();
            Contacts.Add(new Contact { Name = "Emir", ImageUrl = "https://static.toiimg.com/thumb/resizemode-4,msid-76729750,imgsize-249247,width-720/76729750.jpg", Status = "My status" });
            Contacts.Add(new Contact { Name = "Tom", ImageUrl = "https://static.toiimg.com/thumb/resizemode-4,msid-76729750,imgsize-249247,width-720/76729750.jpg" });
            Contacts.Add(new Contact { Name = "Jess", ImageUrl = "https://static.toiimg.com/thumb/resizemode-4,msid-76729750,imgsize-249247,width-720/76729750.jpg" });

            listView.ItemsSource = Contacts;
        }


        async private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //this prevents infinite loop when button is pressed
            if(e.SelectedItem == null)
            {
                return;
            }

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new ContactDetailsPage(contact));

            listView.SelectedItem = null;
        }

        async private void go_to_tabbed_page_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabsShowcasePage());
        }

        async private void go_to_grid_page_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridShowcasePage());
        }

        
    }
}
