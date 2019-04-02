// ALLOWOVERWRITE-2379CFBF2EC2848AEFEDBC40E98D7BF2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using transModel =ToDo.Database.Transactions.Model;
using trans =ToDo.Database.Transactions;
using viewModel =ToDo.Database.Views.Model;
using views =ToDo.Database.Views;


namespace ToDoRestAPI
{

	
    public partial class TaskAPIController : Controller
    {
    
        /// <summary>
        /// Get All Objects for Task
        /// </summary>	
        [Route("api/Task/All")]
        [HttpGet]
        public async Task<List<viewModel.TaskView>> All()
        {
            var views = new views.TaskViews();
            return await views.GetAll();
        }
    
      
    	 /// <summary>
        /// Get Task By TaskId
        /// </summary>	
    	//Get Task View Model
    	[Route("api/Task/{taskId}")]
    	[HttpGet]
        public async Task<viewModel.TaskView> Get([FromRoute]int taskId)
        {
            var view=new views.TaskViews();            
            return await view.Get(taskId);            
        }
    
        
    	 /// <summary>
        /// Add New Task
        /// </summary>	
    
    	//Add New Task
    	[Route("api/Task")]
    	[HttpPost]
        public async Task<viewModel.TaskView> Add([FromBody]transModel.TaskAdd add)
        {
            var addTrans=new trans.TaskTransactions(); 
            var result=await addTrans.Add(add);
            return (viewModel.TaskView) result;
        }
        
      
         /// <summary>
        /// Update Task By TaskId
        /// </summary>	
       
        
        //Update  Task
    	[Route("api/Task/{taskId}")]
    	[HttpPut]
        public async Task<viewModel.TaskView> Update([FromRoute]int taskId,[FromBody]transModel.TaskUpdate update)
        {
        	update.TaskId = taskId;
            var updateTrans=new trans.TaskTransactions();
            var result=await updateTrans.Update(update);
            return (viewModel.TaskView) result;
                     
        }
        
         /// <summary>
        /// Delete Task By TaskId
        /// </summary>
         //Delete  Task
    	[Route("api/Task/{taskId}")]
    	[HttpDelete]
        public async Task Delete([FromRoute]int taskId)
        {
            var deleteTrans=new trans.TaskTransactions();
			var  taskDelete=new transModel.TaskDelete(){TaskId=taskId };			
            await deleteTrans.Delete(taskDelete);            
        }
        
        
        
		
		 /// <summary>
        /// Find all Tasks for User
        /// </summary>
		
		[Route("api/User/{UserId}/Tasks")]
    	 [HttpGet]
        public async Task<List<viewModel.TaskView>> GetTasksForUser([FromRoute]int userId)		
    	{
    		 var view=new views.TaskViews();            
            return await view.GetTasksForUser(userId); 
    	
    	}
    	
		    	
        
    }
}


