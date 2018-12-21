// ALLOWOVERWRITE-A4DBC903F16593C5E61C3F2F799E361A

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Database.Views.Model;
using Database.Views;
using Database.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Database.Mobile.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserIndexPage : ContentPage
    {
        public ObservableCollection<UserView> Items { get; set; }=new ObservableCollection<UserView>();

        public UserIndexPage()
        {
            InitializeComponent();
			MessagingCenter.Subscribe<UserIndexViewModel, UserEditViewModel>(this, "AddUser", async (sender, arg) => { await AddUsers(arg);});                   
        }
        
        
        private async System.Threading.Tasks.Task AddUsers(UserEditViewModel userEditViewModel)
        {

            var page = new UserEditPage();
            page.BindingContext = userEditViewModel;
            await Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, true);
        }
        
        

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            var page = new UserEditPage();
            await Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, true);
			await ((UserEditViewModel)page.BindingContext).Load(((UserView) e.Item).UserId);
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }


        
    }

}

