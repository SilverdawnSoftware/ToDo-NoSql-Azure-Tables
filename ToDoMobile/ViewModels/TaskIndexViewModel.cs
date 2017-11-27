// ALLOWOVERWRITE-81C5FC33A0ED0E27D7A059460D3AA898

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Views;
using ToDo.Views.Model;
using ToDoMobile.Annotations;
using ToDoMobile.Views.User;
using Xamarin.Forms;

namespace ToDoMobile.ViewModels
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

