// ALLOWOVERWRITE-3D02DEEFA970AF6D4623A1CA0361A73F

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.ViewModels;
using ToDoMobile.Views.Task;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.Views.Task
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