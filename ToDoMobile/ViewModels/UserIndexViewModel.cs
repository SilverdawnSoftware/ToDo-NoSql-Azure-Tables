// ALLOWOVERWRITE-BC2A7E8C18273AAE90738D99D9F4086A

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
    public class UserIndexViewModel : INotifyPropertyChanged
    {


		 public ICommand AddUserCommand { get; private set; }

        public UserIndexViewModel()
        {
            AddUserCommand = new Command(async () => await AddUser());
        }

        private async Task AddUser()
        {
            var user=new UserEditViewModel();

            MessagingCenter.Send<UserIndexViewModel, UserEditViewModel>(this, "AddUser", user);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<UserView> UserViews { get; set; } = new ObservableCollection<UserView>();

        
        public async System.Threading.Tasks.Task GetUsers()
        {
            var Users = new UserViews();

            var temp = await Users.GetAll();

            //Items.Add(temp.First());

            UserViews.Clear();

            foreach (var userView in temp)
            {
                UserViews.Add(userView);
            }
        }
        
        
        
    }
}

