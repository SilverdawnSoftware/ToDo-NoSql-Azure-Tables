// ALLOWOVERWRITE-690B05697539BBAA0D06581D1AB1161C

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using SilverdawnSoftware.Exceptions;
using ToDo.Database.Views.Model;


namespace ToDo.Database.Views
{
    public partial class UserViews
    {
    	
    	public async Task<List<UserView>> GetAll()
        {
            try
            {
                var result = new List<UserView>();

                TableContinuationToken token = null;
                TableQuery<Database.User> query = new TableQuery<Database.User>();
                do
                {
                    var userTable = await Utils.GetTable("User");


                    TableQuerySegment<Database.User> seg = await userTable.ExecuteQuerySegmentedAsync<Database.User>(query, token);
                    token = seg.ContinuationToken;
                    result.AddRange(seg.Results.ConvertAll(user => (UserView)user));


                } while (token != null);

                return result;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return null;
            }
        }
    
    	
    	public async Task<UserView> Get(int userId)
    	{
    		
    		try
            {
			   TableOperation retrieveOperation = TableOperation.Retrieve<User>("root", userId.ToString());

                var userTable = await Utils.GetTable("User");

                var result = await userTable.ExecuteAsync(retrieveOperation);

                if (result.Result != null)
                {
                    var user = (Database.User)result.Result;
                    return (UserView)user;
                }
                
	    		
    		 }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                              
            }   
            return null;
    	}
    	
    	
    	
    	
    	
    }
}

