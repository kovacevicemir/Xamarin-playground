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
    public partial class FormShowcaseView : ContentPage
    {
        public FormShowcaseView()
        {
            InitializeComponent();
        }

        //There is another event Text Changed that can be used
        private void Entry_Completed(object sender, EventArgs e)
        {
            password_label.Text = "Completed";
        }
    }
}