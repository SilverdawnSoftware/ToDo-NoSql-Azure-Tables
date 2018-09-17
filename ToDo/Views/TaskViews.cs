// ALLOWOVERWRITE-76D85C1644873CE54E0E30A740ACF15C

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Silverdawn.Exceptions;
using ToDo.Views.Model;
using ToDo.Database;

namespace ToDo.Views
{
    public partial class TaskViews
    {
    	
    	public async Task<List<TaskView>> GetAll()
        {
            try
            {
                var result = new List<TaskView>();

                TableContinuationToken token = null;
                TableQuery<Database.Task> query = new TableQuery<Database.Task>();
                do
                {
                    var taskTable = await Utils.GetTable("Task");


                    TableQuerySegment<Database.Task> seg = await taskTable.ExecuteQuerySegmentedAsync<Database.Task>(query, token);
                    token = seg.ContinuationToken;
                    result.AddRange(seg.Results.ConvertAll(task => (TaskView)task));


                } while (token != null);

                return result;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return null;
            }
        }
    
    	
    	
    	
    	
		
		
		public async Task<TaskView> Get(int userId,int  taskId)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Database.Task>(userId.ToString(), taskId.ToString());

                var taskTable = await Utils.GetTable("Task");

                var result = await taskTable.ExecuteAsync(retrieveOperation);

                if (result.Result != null)
                {
                    var task = (Database.Task)result.Result;
                    return (TaskView)task;
                }
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);

            }
            return null;
        }
		
		
		
		public async Task<TaskView> Get(int taskId)
        {

            try
            {
                TableQuery<Database.Task> query = new TableQuery<Database.Task>().Where(TableQuery.GenerateFilterConditionForInt("TaskId", QueryComparisons.Equal, taskId));

                var taskTable = await Utils.GetTable("Task");

                TableContinuationToken token=new TableContinuationToken();
                var result = await taskTable.ExecuteQuerySegmentedAsync(query, token);

                if (result.Results.Any())
                {
                    var task = (Database.Task)result.Results.First();
                    return (TaskView)task;
                }
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);

            }
            return null;
        }
		
		
		
		
		public async Task<List<TaskView>> GetTasksForUser(int userId)
    	{
    		try
            {
                var result = new List<TaskView>();

                TableContinuationToken token = null;
                TableQuery<Database.Task> query = new TableQuery<Database.Task>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId.ToString()));
                do
                {
                    var taskTable = await Utils.GetTable("Task");

                    TableQuerySegment<Database.Task> seg = await  taskTable.ExecuteQuerySegmentedAsync<Database.Task>(query, token);
                    token = seg.ContinuationToken;
                    result.AddRange(seg.Results.ConvertAll(task => (TaskView)task));

                } while (token != null);

                return result;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return null;
            }
    		
	            
    	}
    	
    }
}

