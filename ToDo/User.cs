// ALLOWOVERWRITE-4DA7F94E0A5AB71D2B6828DF4880A056

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Silverdawn.Exceptions;


namespace ToDo.Database
{
    public class User : TableEntity
    {
	    		
	    /// <summary> Unique identifier for user </summary>	 
	    public int UserId  { get; set; }     	
	    		
	    /// <summary> The title of the user e.g. Mrs,Mr </summary>	 
	    public string Title  { get; set; }     	
	    		
	    /// <summary> The users first name </summary>	 
	    public string FirstName  { get; set; }     	
	    		
	    /// <summary> The users surname </summary>	 
	    public string Surname  { get; set; }     	
	    		
	    /// <summary> The users email address </summary>	 
	    public string Email  { get; set; }     	
	    		
	    /// <summary> The users mobile number </summary>	 
	    public string MobileNumber  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string HomeNumber  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string WorkNumber  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string AddressLine1  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string AddressLine2  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string City  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string Postcode  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string Country  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string Company  { get; set; }     	
	    		
	    /// <summary>  </summary>	 
	    public string Department  { get; set; }     	
    	
    	
    	
    	
    	/// <summary>
       	/// List of Tasks
        /// </summary>
        [IgnoreProperty]
        public List<Task> Tasks
        {
            get
            {
                try
                {
                    var result = new List<Task>();

                    TableContinuationToken token = null;
                    TableQuery<Database.Task> query = new TableQuery<Database.Task>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, UserId.ToString()));
                    do
                    {
                        var taskTable = Utils.GetTable("Task").Result;

                        TableQuerySegment<Database.Task> seg = taskTable.ExecuteQuerySegmentedAsync<Database.Task>(query, token).Result;
                        token = seg.ContinuationToken;
                        result.AddRange(seg.Results);

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
    
    
}



























