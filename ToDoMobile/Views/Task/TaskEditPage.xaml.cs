// ALLOWOVERWRITE-AFD37ED85ACFA59E04559714D96D088F

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Database.Mobile.Views.Task
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskEditPage : ContentPage
	{
		public TaskEditPage ()
		{
			InitializeComponent ();			
			MessagingCenter.Subscribe<TaskEditViewModel>(this, "Save error",model => DisplayAlert("Save error", "Unable to save changes.", "Close") );			 			 
		}
		
		
		
		
	}
}