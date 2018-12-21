// ALLOWOVERWRITE-58F7B032A393FC8B3ED7F9E70C069F21

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Silverdawn.Exceptions;
using Database.Views.Model;


namespace Database.Views
{
    public partial class TaskViews
    {
        
    	public async Task<List<TaskView>> GetAll()
        {
        	try
            {       
	            var client = new HttpClient();
	          
	            var serializer = new DataContractJsonSerializer(typeof(List<TaskView>),new DataContractJsonSerializerSettings()
	            {
	                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
	            });
	
	            var stream = await client.GetStreamAsync("http://tododotnet.lan:9271/api/task/all");
	
	            var views = serializer.ReadObject(stream) as List<TaskView>;
	            
	            return views;
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;              
            }    
        }
    
    
    	
    	public async Task<TaskView> Get(int taskId)
    	{
    		try
            {
	    		var client = new HttpClient();
	
	            var serializer = new DataContractJsonSerializer(typeof(TaskView),new DataContractJsonSerializerSettings()
	            {
	                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
	            });
	
	            var stream = await client.GetStreamAsync($"http://tododotnet.lan:9271/api/task/{taskId}");
	
	            var view = serializer.ReadObject(stream) as TaskView;
	
	            return view;
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;              
            }    
    	
    	}
    	
    	
    	
    	
    	
		
		 /// <summary>
        /// Find all Tasks for User
        /// </summary>
		
		public async Task<List<TaskView>> GetAllForUser(int userId)
        {
        	try
            {
	            var client = new HttpClient();
	          
	            var serializer = new DataContractJsonSerializer(typeof(List<TaskView>),new DataContractJsonSerializerSettings()
	            {
	                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
	            });
	
	            var stream = await client.GetStreamAsync($"http://tododotnet.lan:9271/api/user/{userId}/tasks");
	
	            var views = serializer.ReadObject(stream) as List<TaskView>;
	            
	            return views;
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }    
        }
		    	
    	
    }
}

