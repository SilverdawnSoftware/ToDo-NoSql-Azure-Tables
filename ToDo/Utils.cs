﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ToDo.Database
{
    public class Utils
    {


        public static CloudTableClient GetTableClient()
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true;");

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


            return tableClient;
        }


        public static async Task<CloudTable> GetTable(string table)
        {
            var cloudTable = GetTableClient().GetTableReference(table);
            await cloudTable.CreateIfNotExistsAsync();
            return cloudTable;
        }


    }
}
