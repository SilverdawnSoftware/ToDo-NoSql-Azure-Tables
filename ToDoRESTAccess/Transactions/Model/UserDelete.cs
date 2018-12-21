// ALLOWOVERWRITE-11212055BCDB221E211359988B5D7AE6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Database.Transactions.Model
{
	[DataContract]
    public class UserDelete
    {
    	
    	
    	/// <summary>
        /// Unique identifier for user
        /// </summary>
		 [DataMember(Name = "userId")]         
    	public int  UserId  { get; set; } 
    	
    }
}