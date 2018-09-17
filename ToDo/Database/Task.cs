// ALLOWOVERWRITE-93ADA8E00500384088251F6C7CC60C86

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Silverdawn.Exceptions;


namespace ToDo.Database
{
    public class Task : TableEntity
    {
	    		
	    /// <summary> Unique identifier for a task </summary>	 
	    public int TaskId  { get; set; }     	
	    		
	    /// <summary> The name of the task to be done </summary>	 
	    public string Name  { get; set; }     	
	    		
	    /// <summary> When the task needs to be completed by </summary>	 
	    public DateTime DueDate  { get; set; }     	
	    		
	    /// <summary> When the task was started </summary>	 
	    public DateTime StartedDate  { get; set; }     	
	    		
	    /// <summary> The status of the task e.g, Inprogress, Completed </summary>	 
	    public int Status  { get; set; }     	
	    		
	    /// <summary> The data the task was completed </summary>	 
	    public DateTime CompletedDate  { get; set; }     	
    	
    	
    	
    	//parent of task
        public int UserUserId { get; set; }
    	
    	
    	/// <summary>
        /// Reference to  User
        /// </summary>	
    	public User User
        {
            get
            {
                try
                {
                    var result = new List<User>();

                    TableContinuationToken token = null;
                    var query = new TableQuery<Database.User>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, UserUserId.ToString()));

                    var userTable = Utils.GetTable("User").Result;

                    var seg = userTable.ExecuteQuerySegmentedAsync<Database. User>(query, token).Result;
                    token = seg.ContinuationToken;
                    return seg.Results.First();

                }
                catch (Exception e)
                {
                    LogFactory.GetLogger().Log(LogLevel.Error, e);

                }
                return null;
            }
        }
        
    	
    	
    	
    	
    	
    }
    
    
}



























