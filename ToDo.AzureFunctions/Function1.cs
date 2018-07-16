using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ToDo.Views;
using Silverdawn.Exceptions;
using trans=ToDo.Transactions;


namespace ToDo.AzureFunctions
{
    public static class Function1
    {


        [FunctionName("UserByUserId")]
        public static async Task<HttpResponseMessage> UserByUserId([HttpTrigger(AuthorizationLevel.Anonymous, "get","post","put","delete", Route = "user/{userId}")]HttpRequestMessage req, string userId, TraceWriter log)
        {

          

            switch (req.Method.Method.ToUpper())
            {
                case "GET":
                    int useridParamenter;
                    if (int.TryParse(userId, out useridParamenter))
                    {
                        return await GetUserById(useridParamenter);
                    }
                    else if (userId.Trim().ToUpper().Equals("ALL"))
                    {
                        return await GetAllUsers();
                    }

                    break;
               
                case "POST":
                    return await Add(req);
                case "PUT":
                    return await Update(userId, req);
                    break;
                case "DELETE":
                     return await Delete(userId);
                    break;

            }

            return  GetResponse(HttpStatusCode.NotFound);

        }

        [FunctionName("AddUser")]
        public static async Task<HttpResponseMessage> AddUser([HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = "user")] HttpRequestMessage req, TraceWriter log)
        {
            return await Add(req);
        }

        private static HttpResponseMessage GetResponse(HttpStatusCode httpStatusCode)
        {
            var response=new HttpResponseMessage(httpStatusCode);

            //response.Headers.Add("Access-Control-Allow-Credentials", "true");
            //response.Headers.Add("Access-Control-Allow-Origin", "*");
            //response.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");

            return response;
        }


        /// <summary>
        /// Get User By UserId
        /// </summary>
        private static async Task<HttpResponseMessage> GetUserById(int useridParamenter)
        {
            try
            {
                var view = new UserViews();
                var user = await view.Get(useridParamenter);

                if (user==null) return  GetResponse(HttpStatusCode.NotFound);

                var jsonToReturn = JsonConvert.SerializeObject(user, JsonSettings());

                var response = GetResponse(HttpStatusCode.OK);
                response.Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json");
                

                return response;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error,e, "Error in GetUserById");
            }

            return  new HttpResponseMessage(HttpStatusCode.InternalServerError);
          
        }

        public static JsonSerializerSettings JsonSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new LowercaseNamingStrategy() },
            };

            return settings;
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        public static async Task<HttpResponseMessage> GetAllUsers()
        {
            try
            {
                var views = new UserViews();

                var users = await views.GetAll();

                if (users == null) return  GetResponse(HttpStatusCode.NotFound);


              

                var jsonToReturn = JsonConvert.SerializeObject(users, JsonSettings());

                var response = GetResponse(HttpStatusCode.OK);
                response.Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json");
                

                return response;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e, "Error in GetAllUsers");
            }

            return  GetResponse(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Add New User
        /// </summary>	
        private static async Task<HttpResponseMessage> Add(HttpRequestMessage req)
        {
            try
            {

                var content = await req.Content.ReadAsStringAsync();

                var add = JsonConvert.DeserializeObject<trans.Model.UserAdd>(content);

                var addTrans = new trans.UserTransactions();
                var user = await addTrans.Add(add);

                if (user == null) return  GetResponse(HttpStatusCode.NotFound);

                var jsonToReturn = JsonConvert.SerializeObject(user, JsonSettings());

                var response = GetResponse(HttpStatusCode.OK);
                response.Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e, "Error in GetUserById");
            }

            return  GetResponse(HttpStatusCode.InternalServerError);

        }


        /// <summary>
        /// Update User By UserId
        /// </summary>	
        private static async Task<HttpResponseMessage> Update(string userId,HttpRequestMessage req)
        {
            try
            {
                int id;

                if (int.TryParse(userId, out id))
                {
                    var content = await req.Content.ReadAsStringAsync();

                    var update = JsonConvert.DeserializeObject<trans.Model.UserUpdate>(content);
                    update.UserId = id;
                        var addTrans = new trans.UserTransactions();
                    var user = await addTrans.Update(update);

                    if (user == null) return GetResponse(HttpStatusCode.NotFound);

                    var jsonToReturn = JsonConvert.SerializeObject(user, JsonSettings());

                    var response = GetResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json");

                    return response;
                }
            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e, "Error in GetUserById");
            }

            return  GetResponse(HttpStatusCode.InternalServerError);

        }

        /// <summary>
        /// Delete User By UserId
        /// </summary>
        private static async Task<HttpResponseMessage> Delete(string userId)
        {
            try
            {

                int id;

                if (int.TryParse(userId, out id))
                {
                    var deleteTrans = new trans.UserTransactions();
                    var userDelete = new trans.Model.UserDelete() {UserId = id};
                    await deleteTrans.Delete(userDelete);
                    var response =  GetResponse(HttpStatusCode.OK);

                    return response;
                }

                return  GetResponse(HttpStatusCode.NotFound);



            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e, "Error in GetUserById");
            }

            return  GetResponse(HttpStatusCode.InternalServerError);

        }

    }


    public class LowercaseNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string str)
        {
            if (String.IsNullOrEmpty(str))
                return String.Empty;
            return Char.ToLower(str[0]) + str.Substring(1);
           
        }
    }
}
