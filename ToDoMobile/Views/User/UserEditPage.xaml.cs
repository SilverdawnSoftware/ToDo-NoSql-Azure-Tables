// ALLOWOVERWRITE-CBA8D285BE909AE772EDC9BED74E5038

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.ViewModels;
using ToDoMobile.Views.Task;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.Views.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserEditPage : ContentPage
	{
		public UserEditPage ()
		{
			InitializeComponent ();			
			MessagingCenter.Subscribe<UserEditViewModel>(this, "Save error",model => DisplayAlert("Save error", "Unable to save changes.", "Close") );			 			 
           	MessagingCenter.Subscribe<UserEditViewModel, TaskIndexViewModel>(this, "ShowTasks",async  (sender, arg) => { await ShowTasks(arg); });
		}
		
		
           	
        public async System.Threading.Tasks.Task ShowTasks(TaskIndexViewModel taskIndexViewModel)
	    {
	        var page = new TaskIndexPage();
	        await Navigation.PushAsync(page);
	        NavigationPage.SetHasBackButton(page, true);
	        page.BindingContext = taskIndexViewModel;
        }           	
           	
		
		
	}
}