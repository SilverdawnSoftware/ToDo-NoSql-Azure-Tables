// ALLOWOVERWRITE-851E67B226A109C4F0579505047FBB10

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Views.Model
{

    public class UserView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  AddressLine1  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  AddressLine2  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  City  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  Company  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  Country  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  Department  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users email address
            /// </summary>
	    	public string  Email  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users first name
            /// </summary>
	    	public string  FirstName  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  HomeNumber  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users mobile number
            /// </summary>
	    	public string  MobileNumber  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  Postcode  { get; set; } 	    	
	    	
	    	
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
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public string  WorkNumber  { get; set; } 	    	
    	    	
    	
    	
    	public static explicit operator UserView(Database.User item)
    	{
    	 var result=new UserView();
    	 
	    	result.AddressLine1 = item.AddressLine1;     
	    	result.AddressLine2 = item.AddressLine2;     
	    	result.City = item.City;     
	    	result.Company = item.Company;     
	    	result.Country = item.Country;     
	    	result.Department = item.Department;     
	    	result.Email = item.Email;     
	    	result.FirstName = item.FirstName;     
	    	result.HomeNumber = item.HomeNumber;     
	    	result.MobileNumber = item.MobileNumber;     
	    	result.Postcode = item.Postcode;     
	    	result.Surname = item.Surname;     
	    	result.Title = item.Title;     
	    	result.UserId = item.UserId;     
	    	result.WorkNumber = item.WorkNumber;     
    	
    	
    	
    	return result;
     }   
   
    }
}


