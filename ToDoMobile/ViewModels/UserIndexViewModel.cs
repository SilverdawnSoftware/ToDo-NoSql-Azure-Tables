// ALLOWOVERWRITE-50C6B3B9BB2ADCB3B442C7CDD531594B

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

