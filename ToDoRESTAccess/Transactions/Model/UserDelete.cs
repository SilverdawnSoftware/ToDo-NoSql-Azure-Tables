// ALLOWOVERWRITE-B0C404DCEF67036FA10B14EDB3EF7B10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace ToDo.Transactions.Model
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