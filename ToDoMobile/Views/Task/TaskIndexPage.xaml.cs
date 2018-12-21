// ALLOWOVERWRITE-277AE7DD6A192B0C205BFDF4CD47F8A9

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

namespace Database.Mobile.Views.Task
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskIndexPage : ContentPage
    {
        public ObservableCollection<TaskView> Items { get; set; }=new ObservableCollection<TaskView>();

        public TaskIndexPage()
        {
            InitializeComponent();
			MessagingCenter.Subscribe<TaskIndexViewModel, TaskEditViewModel>(this, "AddTask", async (sender, arg) => { await AddTasks(arg);});                   
        }
        
        
        private async System.Threading.Tasks.Task AddTasks(TaskEditViewModel taskEditViewModel)
        {

            var page = new TaskEditPage();
            page.BindingContext = taskEditViewModel;
            await Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, true);
        }
        
        

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            var page = new TaskEditPage();
            await Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, true);
			await ((TaskEditViewModel)page.BindingContext).Load(((TaskView) e.Item).TaskId);
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }


        
    }

}

