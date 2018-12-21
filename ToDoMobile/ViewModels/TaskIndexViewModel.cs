// ALLOWOVERWRITE-9873DCF002FDEC3B1A641FC513D6BE2A

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Database.Views;
using Database.Views.Model;
using Database.Mobile.Annotations;

using Xamarin.Forms;

namespace Database.Mobile.ViewModels
{
    public class TaskIndexViewModel : INotifyPropertyChanged
    {


		 public ICommand AddTaskCommand { get; private set; }

        public TaskIndexViewModel()
        {
            AddTaskCommand = new Command(async () => await AddTask());
        }

        private async Task AddTask()
        {
            var task=new TaskEditViewModel();

 			task.UserUserId= UserUserId; 
            MessagingCenter.Send<TaskIndexViewModel, TaskEditViewModel>(this, "AddTask", task);
        }

 		public int UserUserId {get; set;} 


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<TaskView> TaskViews { get; set; } = new ObservableCollection<TaskView>();

		
        public async System.Threading.Tasks.Task GetTasksForUser(int userUserId)
        {
        	UserUserId=userUserId;
            var Tasks = new TaskViews();
            var temp = await Tasks.GetAllForUser(userUserId);
            TaskViews.Clear();
            foreach (var taskView in temp)
            {
                TaskViews.Add(taskView);
            }
        }
        
        
    }
}

