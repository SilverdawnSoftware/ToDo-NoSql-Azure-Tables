// ALLOWOVERWRITE-3843ACD09A7864924959C465D33952DD

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silverdawn.Exceptions;
using Microsoft.WindowsAzure.Storage.Table;
using ToDo.Transactions.Model;
using ToDo.Views.Model;
using data = ToDo.Database;

namespace ToDo.Transactions
{
 public partial class UserTransactions
 {
    
      public async Task<data.User> Add( UserAdd add)
        {
            try
            {

                var newUser=new data.User();
	    		newUser.AddressLine1 = add.AddressLine1;   	
	    		newUser.AddressLine2 = add.AddressLine2;   	
	    		newUser.City = add.City;   	
	    		newUser.Company = add.Company;   	
	    		newUser.Country = add.Country;   	
	    		newUser.Department = add.Department;   	
	    		newUser.Email = add.Email;   	
	    		newUser.FirstName = add.FirstName;   	
	    		newUser.HomeNumber = add.HomeNumber;   	
	    		newUser.MobileNumber = add.MobileNumber;   	
	    		newUser.Postcode = add.Postcode;   	
	    		newUser.Surname = add.Surname;   	
	    		newUser.Title = add.Title;   	
	    		newUser.WorkNumber = add.WorkNumber;   	
                
                newUser.UserId = await data.Sequence.SequenceGenerator.GetNextId("User");
                newUser.RowKey = newUser.UserId.ToString();  
				newUser.PartitionKey ="root";
                TableOperation insertOperation = TableOperation.Insert(newUser);
                var userTable = await data.Utils.GetTable("User");
                await userTable.ExecuteAsync(insertOperation);
                return newUser;
            }

            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return null;

            }
        }
 	
 	
 	




 	
 	 public async Task<data.User> Update(UserUpdate update)
     {
         try
         {
            
             TableOperation retrieveOperation = TableOperation.Retrieve<data.User>("root", update.UserId.ToString());

             var userIdTable = await data.Utils.GetTable("User");

             var result = await userIdTable.ExecuteAsync(retrieveOperation);

             if (result.Result != null)
             {
				var userToUpdate = (data.User) result.Result;	
                userToUpdate.AddressLine1 = update.AddressLine1;   	
                userToUpdate.AddressLine2 = update.AddressLine2;   	
                userToUpdate.City = update.City;   	
                userToUpdate.Company = update.Company;   	
                userToUpdate.Country = update.Country;   	
                userToUpdate.Department = update.Department;   	
                userToUpdate.Email = update.Email;   	
                userToUpdate.FirstName = update.FirstName;   	
                userToUpdate.HomeNumber = update.HomeNumber;   	
                userToUpdate.MobileNumber = update.MobileNumber;   	
                userToUpdate.Postcode = update.Postcode;   	
                userToUpdate.Surname = update.Surname;   	
                userToUpdate.Title = update.Title;   	
                userToUpdate.UserId = update.UserId;   	
                userToUpdate.WorkNumber = update.WorkNumber;   	
            	
    			 TableOperation updateOperation = TableOperation.Replace(userToUpdate);

                 // Execute the operation.
                 await userIdTable.ExecuteAsync(updateOperation);
    		
    		
    			return userToUpdate;
            	}
            }
            
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
               
              
            }
             return null;
        }


	// Delete Transaction Code
 	
 	 public async Task Delete( UserDelete delete)
     {
         try
         {
            	TableOperation retrieveOperation = TableOperation.Retrieve<data.User>("root", delete.UserId.ToString());

                var userTable = await data.Utils.GetTable("User");

                var result = await userTable.ExecuteAsync(retrieveOperation);

                if (result.Result != null)
                {
                    var deleteEntity = (data.User)result.Result;
                    TableOperation deleteOperation = TableOperation.Delete(deleteEntity);

                    // Execute the operation.
                    await userTable.ExecuteAsync(deleteOperation);
                }
             
    		}
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
            }
        }
        

	}
 }
 
