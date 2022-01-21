using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListRow : ViewCell
    {   
        //Example of bindableProperty
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Label", typeof(string), typeof(ListRow), null);
        public string Name
        {
            get { return (String)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty StatusProperty =
            BindableProperty.Create("Label", typeof(string), typeof(ListRow), null);
        public string Status
        {
            get { return (String)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create("Image", typeof(string), typeof(ListRow), null);
        public string ImageUrl
        {
            get { return (String)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        
        public ListRow()
        {
            InitializeComponent();

            BindingContext = this;
        }

        async private void Call_Pressed(object sender, EventArgs e)
        {
            //Example of passing dynamic paramete (Command parameter) as event argument 
            string caller = ((Button)sender).CommandParameter as string;

            //Example how to reach components that are out of reach
            await App.Current.MainPage.DisplayAlert("Calling", caller, "OK");
        }
    }
}