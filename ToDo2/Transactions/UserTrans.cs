// ALLOWOVERWRITE-83F35800F0089D8B91F88F0F4E08F792

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
	            using (var db = new data.ToDoDbContext())
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
 	
 	
 	 public async Task<data.User> Add(data.ToDoDbContext db, UserAdd add)
        {
         try
            {
            
               var newUser=new data.User();
	    	newUser.Email = add.Email;   	
	    	newUser.FirstName = add.FirstName;   	
	    	newUser.MobileNumber = add.MobileNumber;   	
	    	newUser.Surname = add.Surname;   	
	    	newUser.Title = add.Title;   	
    	
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
	            using (var db = new data.ToDoDbContext())
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
 	
 	
 	 public async Task<data.User> Update(data.ToDoDbContext db, UserUpdate update)
        {
         try
            {
              var userToUpdate = await db.Users.FirstOrDefaultAsync(w => w.UserId == update.UserId);

               
            	
userToUpdate.Email = update.Email;   	
userToUpdate.FirstName = update.FirstName;   	
userToUpdate.MobileNumber = update.MobileNumber;   	
userToUpdate.Surname = update.Surname;   	
userToUpdate.Title = update.Title;   	
userToUpdate.UserId = update.UserId;   	
            	
    	
    		
    		
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
	            using (var db = new data.ToDoDbContext())
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
 	
 	
 	 public async Task Delete(data.ToDoDbContext db, UserDelete delete)
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
 
