using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using ToDo.Transactions;
using ToDo.Transactions.Model;
using ToDo.Views;
using Xunit;

namespace ToDo.Tests
{
    public class UserTests
    {
        [Fact]
        public async void AddUserTest()
        {
            var adduser = new UserAdd()
            {
                Email = Guid.NewGuid().ToString()
            };


            var userTrans = new UserTransactions();
            var userView = new UserViews();


            var user=await userTrans.Add(adduser);

            var userview = await userView.Get(user.UserId);


            user.UserId.Should().Be(userview.UserId);

            user.Email.Should().Be(userview.Email);

        }


        [Fact]
        public async void DeleteUserTest()
        {
            var adduser = new UserAdd()
            {
                Email = Guid.NewGuid().ToString()
            };


            var userTrans = new UserTransactions();
            var userView = new UserViews();


            var user = await userTrans.Add(adduser);

            await userTrans.Delete(new UserDelete() {UserId = user.UserId});

            var userview = await userView.Get(user.UserId);


            userview.Should().BeNull();
        }

        [Fact]
        public async void UpdateUserTest()
        {
            var adduser = new UserAdd()
            {
                Email = Guid.NewGuid().ToString()
            };


            var userTrans = new UserTransactions();
            var userView = new UserViews();


            var user = await userTrans.Add(adduser);

            var updateuser=new UserUpdate(){UserId = user.UserId,Email = user.Email,FirstName = "Daniel"};

            await userTrans.Update(updateuser);

            var userview = await userView.Get(user.UserId);
            user.UserId.Should().Be(userview.UserId);
            user.Email.Should().Be(userview.Email);
            userview.FirstName.Should().Be("Daniel");
        }

        [Fact]
        public async void GetTasksForUser()
        {
            var adduser = new UserAdd()
            {
                Email = Guid.NewGuid().ToString()
            };


            var userTrans = new UserTransactions();
            var userView = new UserViews();


            var user = await userTrans.Add(adduser);

            for (int i = 0; i < 10; i++)
            {
                var taskTrans=new TaskTransactions();
                await taskTrans.Add(new TaskAdd() {Name = Guid.NewGuid().ToString(), UserUserId = user.UserId,CompletedDate =new DateTime(1900,1,1),DueDate = DateTime.Now.AddDays(30),StartedDate = DateTime.Now});
            }

            var taskviews=new TaskViews();

            var tasks = await taskviews.GetTasksForUser(user.UserId);

            tasks.Should().HaveCount(10);
            user.Tasks.Should().HaveCount(10);

            var first = user.Tasks.First();
            user.Tasks.First().User.UserId.Should().Be(user.UserId);

        }


       



    }
}
