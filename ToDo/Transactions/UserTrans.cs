// ALLOWOVERWRITE-6D21D34E227A1548B8A85DCB97E4F619

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silverdawn.Exceptions;
using ToDo.Transactions.Model;
using ToDo.Views.Model;
using data = ToDo.Database;

namespace ToDo.Transactions
{
 public partial class UserTransactions
 {
     
 
 		// Add Transaction Code
 		public async Task<UserView> Add(UserAdd add)
        {
        	try
            {
	            using (var db = new data.())
	            {
	                var result= await Add(db,add);
	                await db.SaveChangesAsync();
	                return (UserView)result;
	            }
	        }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            } 
        } 	
 	
 	
 	 public async Task<data.User> Add(data. db, UserAdd add)
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
    	
    		// Add references to parent Classes
    	
    	
    		db.Users.Add(newUser);
    		
    		return newUser;
            }
            
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }
        }



// Update Transaction Code
 		public async Task<UserView> Update(UserUpdate update)
        {
        	try
            {
	            using (var db = new data.())
	            {
	                var result= await Update(db,update);
	                await db.SaveChangesAsync();
	                return (UserView)result;
	            }
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            } 
        } 	
 	
 	
 	 public async Task<data.User> Update(data. db, UserUpdate update)
        {
         try
            {
              var userToUpdate = await db.Users.FirstOrDefaultAsync(w => w.UserId == update.UserId);

               
            	
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
            	
    	
    		
    		
    		return userToUpdate;
            }
            
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }
        }


	// Delete Transaction Code
 		public async Task Delete(UserDelete delete)
        {
        	try
            {
	            using (var db = new data.())
	            {
	                await Delete(db,delete);
	                await db.SaveChangesAsync();	                
	            }
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
               
              
            } 
        } 	
 	
 	
 	 public async Task Delete(data. db, UserDelete delete)
        {
         try
            {
            
              var userToDelete = await db.Users.FirstOrDefaultAsync(w => w.UserId == delete.UserId);
            
             	db.Users.Remove(userToDelete);    		
    		}
             catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
            }
        }
        

	}
 }
 
