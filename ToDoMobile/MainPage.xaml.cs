using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Mobile.ViewModels;
using Database.Mobile.Views.User;


using Xamarin.Forms;

namespace ToDoMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


       

        public async void Users_Clicked(object sender, EventArgs args)
        {
          
            var page = new UserIndexPage();
            await Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page,true);
            await ((UserIndexViewModel)page.BindingContext).GetUsers();

        }
    }
}
