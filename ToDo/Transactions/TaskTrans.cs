// ALLOWOVERWRITE-2A2826F71404D38AD206B84B9ACC7F2D

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverdawnSoftware.Exceptions;
using Microsoft.WindowsAzure.Storage.Table;
using ToDo.Database.Transactions.Model;
using ToDo.Database.Views.Model;
using data = ToDo.Database;

namespace ToDo.Database.Transactions
{
 public partial class TaskTransactions
 {
    
      public async Task<data.Task> Add( TaskAdd add)
        {
            try
            {

                var newTask=new data.Task();
	    		newTask.CompletedDate = add.CompletedDate;   	
	    		newTask.DueDate = add.DueDate;   	
	    		newTask.Name = add.Name;   	
	    		newTask.StartedDate = add.StartedDate;   	
	    		newTask.Status = add.Status;   	
                
                newTask.TaskId = await data.Sequence.SequenceGenerator.GetNextId("Task");
                newTask.RowKey = newTask.TaskId.ToString();  
		    	newTask.UserUserId = add.UserUserId;
		    	newTask.PartitionKey = add.UserUserId.ToString();
                TableOperation insertOperation = TableOperation.Insert(newTask);
                var taskTable = await data.Utils.GetTable("Task");
                await taskTable.ExecuteAsync(insertOperation);
                return newTask;
            }

            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return null;

            }
        }
 	
 	
 	




 	
 	 public async Task<data.Task> Update(TaskUpdate update)
     {
         try
         {
            
             TableOperation retrieveOperation = TableOperation.Retrieve<data.Task>("root", update.TaskId.ToString());

             var taskIdTable = await data.Utils.GetTable("Task");

             var result = await taskIdTable.ExecuteAsync(retrieveOperation);

             if (result.Result != null)
             {
				var taskToUpdate = (data.Task) result.Result;	
                taskToUpdate.CompletedDate = update.CompletedDate;   	
                taskToUpdate.DueDate = update.DueDate;   	
                taskToUpdate.Name = update.Name;   	
                taskToUpdate.StartedDate = update.StartedDate;   	
                taskToUpdate.Status = update.Status;   	
                taskToUpdate.TaskId = update.TaskId;   	
            	
    			 TableOperation updateOperation = TableOperation.Replace(taskToUpdate);

                 // Execute the operation.
                 await taskIdTable.ExecuteAsync(updateOperation);
    		
    		
    			return taskToUpdate;
            	}
            }
            
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
               
              
            }
             return null;
        }


	// Delete Transaction Code
 	
 	 public async System.Threading.Tasks.Task Delete( TaskDelete delete)
     {
         try
         {
            	TableOperation retrieveOperation = TableOperation.Retrieve<data.Task>("root", delete.TaskId.ToString());

                var taskTable = await data.Utils.GetTable("Task");

                var result = await taskTable.ExecuteAsync(retrieveOperation);

                if (result.Result != null)
                {
                    var deleteEntity = (data.Task)result.Result;
                    TableOperation deleteOperation = TableOperation.Delete(deleteEntity);

                    // Execute the operation.
                    await taskTable.ExecuteAsync(deleteOperation);
                }
             
    		}
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
            }
        }
        

	}
 }
 
