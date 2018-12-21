// ALLOWOVERWRITE-3E6FFCF8FA643D5D4C4D485144540070

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Database.Views.Model
{

	[DataContract]
    public class UserView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "addressLine1")]            
	    	public string  AddressLine1  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "addressLine2")]            
	    	public string  AddressLine2  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "city")]            
	    	public string  City  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "company")]            
	    	public string  Company  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "country")]            
	    	public string  Country  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "department")]            
	    	public string  Department  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users email address
            /// </summary>
			 [DataMember(Name = "email")]            
	    	public string  Email  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users first name
            /// </summary>
			 [DataMember(Name = "firstName")]            
	    	public string  FirstName  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "homeNumber")]            
	    	public string  HomeNumber  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users mobile number
            /// </summary>
			 [DataMember(Name = "mobileNumber")]            
	    	public string  MobileNumber  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "postcode")]            
	    	public string  Postcode  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The users surname
            /// </summary>
			 [DataMember(Name = "surname")]            
	    	public string  Surname  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The title of the user e.g. Mrs,Mr
            /// </summary>
			 [DataMember(Name = "title")]            
	    	public string  Title  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// Unique identifier for user
            /// </summary>
			 [DataMember(Name = "userId")]            
	    	public int  UserId  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "workNumber")]            
	    	public string  WorkNumber  { get; set; } 	    	
    	    	
    	
    	
    	
   
    }
}


