// ALLOWOVERWRITE-902B3E3BE141E3BAA260C9DE8D6AF4E8

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Database.Transactions;
using Database.Transactions.Model;
using Database.Views;
using Database.Views.Model;
using Database.Mobile.Annotations;

using Xamarin.Forms;

namespace Database.Mobile.ViewModels
{

    public class TaskEditViewModel : INotifyPropertyChanged
    {


        public TaskEditViewModel()
        {
            SaveCommand=new Command( async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
            
        }

      

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }




        public async Task Cancel()
        {
            if (TaskView.TaskId> 0)
                await Load(TaskView.TaskId);
            else
                TaskView=new TaskView();
        }

        public async Task Load(int taskId)
        {
            var uv=new TaskViews();

            this.TaskView = await uv.Get(taskId);
        }



        public async Task Save()
        {
        	try
        	{
	            var uv = new TaskTransactions();
	
	            if (TaskView.TaskId > 0)
	            {
	                TaskView = await uv.TaskUpdate(this.GetTaskUpdate());
	            }
	            else
	            {
	                TaskView = await uv.TaskAdd(this.GetTaskAdd());
	            }
            }
            catch (Exception ex)
            {
            	 MessagingCenter.Send(this, "Save error");
            }
          
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private TaskView _taskView = new TaskView();

        public TaskView TaskView
        {
            get
            {
                return _taskView;
            }

            set
            {
                this._taskView = value;
                OnPropertyChanged("CompletedDate");
                OnPropertyChanged("DueDate");
                OnPropertyChanged("Name");
                OnPropertyChanged("StartedDate");
                OnPropertyChanged("Status");
                OnPropertyChanged("TaskId");
                              
            }
        }

		
       	 
        /// <summary>
        /// 
        /// </summary>	
        public DateTime  CompletedDate 
        {
            set
            {
                if (TaskView.CompletedDate != value)
                {
                    TaskView.CompletedDate = value;
                    OnPropertyChanged("CompletedDate");
                }
            }
            get
            {
                return TaskView.CompletedDate;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public DateTime  DueDate 
        {
            set
            {
                if (TaskView.DueDate != value)
                {
                    TaskView.DueDate = value;
                    OnPropertyChanged("DueDate");
                }
            }
            get
            {
                return TaskView.DueDate;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Name 
        {
            set
            {
                if (TaskView.Name != value)
                {
                    TaskView.Name = value;
                    OnPropertyChanged("Name");
                }
            }
            get
            {
                return TaskView.Name;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public DateTime  StartedDate 
        {
            set
            {
                if (TaskView.StartedDate != value)
                {
                    TaskView.StartedDate = value;
                    OnPropertyChanged("StartedDate");
                }
            }
            get
            {
                return TaskView.StartedDate;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public int  Status 
        {
            set
            {
                if (TaskView.Status != value)
                {
                    TaskView.Status = value;
                    OnPropertyChanged("Status");
                }
            }
            get
            {
                return TaskView.Status;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public int  TaskId 
        {
            set
            {
                if (TaskView.TaskId != value)
                {
                    TaskView.TaskId = value;
                    OnPropertyChanged("TaskId");
                }
            }
            get
            {
                return TaskView.TaskId;
            } 
         } 	    	
	    	
	    	
    	
    	/// <summary>
        /// Unique identifier for user
        /// </summary>	
       
		 public int  UserUserId 
         {
            set
            {
                if (TaskView.UserUserId != value)
                {
                    TaskView.UserUserId = value;
                    OnPropertyChanged("UserUserId");
                }
            }
            get
            {
                return TaskView.UserUserId;
            } 
         } 	    	
		
	    	
	    	

      

        public TaskUpdate GetTaskUpdate()
        {
            var result = new TaskUpdate();

			result.CompletedDate = TaskView.CompletedDate;
			result.DueDate = TaskView.DueDate;
			result.Name = TaskView.Name;
			result.StartedDate = TaskView.StartedDate;
			result.Status = TaskView.Status;
			result.TaskId = TaskView.TaskId;
            return result;
        }

        public TaskAdd GetTaskAdd()
        {
            var result = new TaskAdd();

			result.CompletedDate = TaskView.CompletedDate;
			result.DueDate = TaskView.DueDate;
			result.Name = TaskView.Name;
			result.StartedDate = TaskView.StartedDate;
			result.Status = TaskView.Status;
			result.TaskId = TaskView.TaskId;
            result.UserUserId= TaskView.UserUserId; 
            return result;
        }




        public static explicit operator TaskEditViewModel(TaskView item)
    	{
       	    var result=new TaskEditViewModel();
    	 
			result.CompletedDate = item.CompletedDate;
			result.DueDate = item.DueDate;
			result.Name = item.Name;
			result.StartedDate = item.StartedDate;
			result.Status = item.Status;
			result.TaskId = item.TaskId;
	    	
        	return result;
       }

     
    }
}




