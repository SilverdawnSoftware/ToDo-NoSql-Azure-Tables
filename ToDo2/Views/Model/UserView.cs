// ALLOWOVERWRITE-90B4664124A6715BD5B905E204129B9B

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Views.Model
{

    public class UserView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// The users email address
            /// </summary>	
	    	public string  Email  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users first name
            /// </summary>	
	    	public string  FirstName  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users mobile number
            /// </summary>	
	    	public string  MobileNumber  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users surname
            /// </summary>	
	    	public string  Surname  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The title of the user e.g. Mrs,Mr
            /// </summary>	
	    	public string  Title  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// Unique identifier for user
            /// </summary>	
	    	public int  UserId  { get; set; } 	    	
    	    	
    	
    	
    	public static explicit operator UserView(Database.User item)
    	{
    	 var result=new UserView();
    	 
	    	result.Email = item.Email;     
	    	result.FirstName = item.FirstName;     
	    	result.MobileNumber = item.MobileNumber;     
	    	result.Surname = item.Surname;     
	    	result.Title = item.Title;     
	    	result.UserId = item.UserId;     
    	
    	
    	
    	return result;
     }   
   
    }
}


