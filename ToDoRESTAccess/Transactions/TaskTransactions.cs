// ALLOWOVERWRITE-A7411F14C9F3B6480B4532F76AB7D355

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Silverdawn.Exceptions;
using ToDo.Transactions.Model;
using ToDo.Views.Model;

namespace ToDo.Transactions
{
    public  class TaskTransactions
    {
        public async Task<TaskView> TaskAdd(TaskAdd add)
        {
        	try
            {
	            string json = "";
	
	            var client = new HttpClient();
	
	            using (var ms = new MemoryStream())
	            {
	                var serializer = new DataContractJsonSerializer(typeof(TaskAdd));
	                serializer.WriteObject(ms, add);
	                ms.Position = 0;
	                StreamReader sr = new StreamReader(ms);
	                json = sr.ReadToEnd();
	            }
	
	            var stream = await client.PostAsync("/api/task", new StringContent(json, Encoding.UTF8, "application/json"));
	
	            using (var ms = new MemoryStream())
	            {
	                var serializer = new DataContractJsonSerializer(typeof(TaskView),new DataContractJsonSerializerSettings()
	            	{
	                	DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
	            	});
	                await stream.Content.CopyToAsync(ms);
	                ms.Position = 0;
	                var view = serializer.ReadObject(ms) as TaskView;
	                return view;
	            }
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }    
        }
 
        public async Task<TaskView> TaskUpdate(TaskUpdate update)
        {
        	try
            {
	            string json = "";
	
	            var client = new HttpClient();
	
	            using (var ms = new MemoryStream())
	            {
	                var serializer = new DataContractJsonSerializer(typeof(TaskUpdate),new DataContractJsonSerializerSettings()
	            	{
	                	DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
	            	});
	                serializer.WriteObject(ms, update);
	                ms.Position = 0;
	                StreamReader sr = new StreamReader(ms);
	                json = sr.ReadToEnd();
	            }
	
	            var stream = await client.PutAsync($"/api/task/{update.TaskId}", new StringContent(json, Encoding.UTF8, "application/json"));
	
	            using (var ms = new MemoryStream())
	            {
	                var serializer = new DataContractJsonSerializer(typeof(TaskView));
	                await stream.Content.CopyToAsync(ms);
	                ms.Position = 0;
	                var view = serializer.ReadObject(ms) as TaskView;
	                return view;
	            }
	        }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }    
        }

    }
}

