// ALLOWOVERWRITE-B6C3A18F31D9795964F9AB35F60D4F2F

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

    public class UserEditViewModel : INotifyPropertyChanged
    {


        public UserEditViewModel()
        {
            SaveCommand=new Command( async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
           	
           	ViewTasksCommand = new Command(async () => await ViewTasks());
           	
            
        }

      

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }


           	
           	
        public ICommand ViewTasksCommand { get; private set; }
         
        public async Task ViewTasks()
        {           
                var tasks = new TaskIndexViewModel();
                await tasks.GetTasksForUser(UserId);
                MessagingCenter.Send<UserEditViewModel, TaskIndexViewModel>(this, "ShowTasks", tasks);
        }
           	


        public async Task Cancel()
        {
            if (UserView.UserId> 0)
                await Load(UserView.UserId);
            else
                UserView=new UserView();
        }

        public async Task Load(int userId)
        {
            var uv=new UserViews();

            this.UserView = await uv.Get(userId);
        }



        public async Task Save()
        {
        	try
        	{
	            var uv = new UserTransactions();
	
	            if (UserView.UserId > 0)
	            {
	                UserView = await uv.UserUpdate(this.GetUserUpdate());
	            }
	            else
	            {
	                UserView = await uv.UserAdd(this.GetUserAdd());
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


        private UserView _userView = new UserView();

        public UserView UserView
        {
            get
            {
                return _userView;
            }

            set
            {
                this._userView = value;
                OnPropertyChanged("AddressLine1");
                OnPropertyChanged("AddressLine2");
                OnPropertyChanged("City");
                OnPropertyChanged("Company");
                OnPropertyChanged("Country");
                OnPropertyChanged("Department");
                OnPropertyChanged("Email");
                OnPropertyChanged("FirstName");
                OnPropertyChanged("HomeNumber");
                OnPropertyChanged("MobileNumber");
                OnPropertyChanged("Postcode");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Title");
                OnPropertyChanged("UserId");
                OnPropertyChanged("WorkNumber");
                              
            }
        }

		
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  AddressLine1 
        {
            set
            {
                if (UserView.AddressLine1 != value)
                {
                    UserView.AddressLine1 = value;
                    OnPropertyChanged("AddressLine1");
                }
            }
            get
            {
                return UserView.AddressLine1;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  AddressLine2 
        {
            set
            {
                if (UserView.AddressLine2 != value)
                {
                    UserView.AddressLine2 = value;
                    OnPropertyChanged("AddressLine2");
                }
            }
            get
            {
                return UserView.AddressLine2;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  City 
        {
            set
            {
                if (UserView.City != value)
                {
                    UserView.City = value;
                    OnPropertyChanged("City");
                }
            }
            get
            {
                return UserView.City;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Company 
        {
            set
            {
                if (UserView.Company != value)
                {
                    UserView.Company = value;
                    OnPropertyChanged("Company");
                }
            }
            get
            {
                return UserView.Company;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Country 
        {
            set
            {
                if (UserView.Country != value)
                {
                    UserView.Country = value;
                    OnPropertyChanged("Country");
                }
            }
            get
            {
                return UserView.Country;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Department 
        {
            set
            {
                if (UserView.Department != value)
                {
                    UserView.Department = value;
                    OnPropertyChanged("Department");
                }
            }
            get
            {
                return UserView.Department;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Email 
        {
            set
            {
                if (UserView.Email != value)
                {
                    UserView.Email = value;
                    OnPropertyChanged("Email");
                }
            }
            get
            {
                return UserView.Email;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  FirstName 
        {
            set
            {
                if (UserView.FirstName != value)
                {
                    UserView.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
            get
            {
                return UserView.FirstName;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  HomeNumber 
        {
            set
            {
                if (UserView.HomeNumber != value)
                {
                    UserView.HomeNumber = value;
                    OnPropertyChanged("HomeNumber");
                }
            }
            get
            {
                return UserView.HomeNumber;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  MobileNumber 
        {
            set
            {
                if (UserView.MobileNumber != value)
                {
                    UserView.MobileNumber = value;
                    OnPropertyChanged("MobileNumber");
                }
            }
            get
            {
                return UserView.MobileNumber;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Postcode 
        {
            set
            {
                if (UserView.Postcode != value)
                {
                    UserView.Postcode = value;
                    OnPropertyChanged("Postcode");
                }
            }
            get
            {
                return UserView.Postcode;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Surname 
        {
            set
            {
                if (UserView.Surname != value)
                {
                    UserView.Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
            get
            {
                return UserView.Surname;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  Title 
        {
            set
            {
                if (UserView.Title != value)
                {
                    UserView.Title = value;
                    OnPropertyChanged("Title");
                }
            }
            get
            {
                return UserView.Title;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public int  UserId 
        {
            set
            {
                if (UserView.UserId != value)
                {
                    UserView.UserId = value;
                    OnPropertyChanged("UserId");
                }
            }
            get
            {
                return UserView.UserId;
            } 
         } 	    	
	    	
       	 
        /// <summary>
        /// 
        /// </summary>	
        public string  WorkNumber 
        {
            set
            {
                if (UserView.WorkNumber != value)
                {
                    UserView.WorkNumber = value;
                    OnPropertyChanged("WorkNumber");
                }
            }
            get
            {
                return UserView.WorkNumber;
            } 
         } 	    	
	    	
	    	
	    	
	    	

      

        public UserUpdate GetUserUpdate()
        {
            var result = new UserUpdate();

			result.AddressLine1 = UserView.AddressLine1;
			result.AddressLine2 = UserView.AddressLine2;
			result.City = UserView.City;
			result.Company = UserView.Company;
			result.Country = UserView.Country;
			result.Department = UserView.Department;
			result.Email = UserView.Email;
			result.FirstName = UserView.FirstName;
			result.HomeNumber = UserView.HomeNumber;
			result.MobileNumber = UserView.MobileNumber;
			result.Postcode = UserView.Postcode;
			result.Surname = UserView.Surname;
			result.Title = UserView.Title;
			result.UserId = UserView.UserId;
			result.WorkNumber = UserView.WorkNumber;
            return result;
        }

        public UserAdd GetUserAdd()
        {
            var result = new UserAdd();

			result.AddressLine1 = UserView.AddressLine1;
			result.AddressLine2 = UserView.AddressLine2;
			result.City = UserView.City;
			result.Company = UserView.Company;
			result.Country = UserView.Country;
			result.Department = UserView.Department;
			result.Email = UserView.Email;
			result.FirstName = UserView.FirstName;
			result.HomeNumber = UserView.HomeNumber;
			result.MobileNumber = UserView.MobileNumber;
			result.Postcode = UserView.Postcode;
			result.Surname = UserView.Surname;
			result.Title = UserView.Title;
			result.UserId = UserView.UserId;
			result.WorkNumber = UserView.WorkNumber;
                       return result;
        }




        public static explicit operator UserEditViewModel(UserView item)
    	{
       	    var result=new UserEditViewModel();
    	 
			result.AddressLine1 = item.AddressLine1;
			result.AddressLine2 = item.AddressLine2;
			result.City = item.City;
			result.Company = item.Company;
			result.Country = item.Country;
			result.Department = item.Department;
			result.Email = item.Email;
			result.FirstName = item.FirstName;
			result.HomeNumber = item.HomeNumber;
			result.MobileNumber = item.MobileNumber;
			result.Postcode = item.Postcode;
			result.Surname = item.Surname;
			result.Title = item.Title;
			result.UserId = item.UserId;
			result.WorkNumber = item.WorkNumber;
	    	
        	return result;
       }

     
    }
}




