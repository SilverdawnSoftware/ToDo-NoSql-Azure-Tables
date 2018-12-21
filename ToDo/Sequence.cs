﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Silverdawn.Exceptions;

namespace ToDo.Database
{


    public class Sequence
    {
        public static SequenceGenerator SequenceGenerator = new SequenceGenerator();

    }

    public class SequenceGenerator
    {
        private const int CounterAdvance = 100;

        public const string CounterTableName = "zzzCounters";

        private List<SequenceRecord> TableIds = new List<SequenceRecord>();

        public async Task<int> GetNextId(string table)
        {
            await SequenceGeneratorSemaphore.semaphoreSlim.WaitAsync();
            try
            {

                var counterTable = await Utils.GetTable(CounterTableName);
                


                if (!TableIds.Any(w => w.Table == table))
                {

                    var getCounter = TableOperation.Retrieve<Counter>("default", table);
                    var result = await counterTable.ExecuteAsync(getCounter);

                    //load and update existing record
                    if (result.Result != null)
                    {
                        var counter = (Counter) result.Result;
                        counter.CurrentCounter = counter.CurrentCounter + CounterAdvance;
                        TableIds.Add(new SequenceRecord()
                        {
                            Table = table,
                            NextId = counter.CurrentCounter,
                            SaveId = counter.CurrentCounter + CounterAdvance
                        });
                        TableOperation updateOperation = TableOperation.Replace(counter);

                        await counterTable.ExecuteAsync(updateOperation);
                    }
                    // create and save new record
                    else
                    {
                        var counter = new Counter(table);
                        TableOperation insertOperation = TableOperation.Insert(counter);
                        await counterTable.ExecuteAsync(insertOperation);
                        TableIds.Add(new SequenceRecord()
                        {
                            Table = table,
                            NextId = counter.CurrentCounter,
                            SaveId = counter.CurrentCounter + CounterAdvance
                        });
                    }

                }

                var sr = TableIds.First(w => w.Table == table);
                sr.NextId++;

                if (sr.NextId >= sr.SaveId)
                {
                    var getCounter = TableOperation.Retrieve<Counter>("default", table);
                    var result = await counterTable.ExecuteAsync(getCounter);
                    var counter = (Counter) result.Result;
                    counter.CurrentCounter = sr.NextId;
                    TableOperation updateOperation = TableOperation.Replace(counter);
                    await counterTable.ExecuteAsync(updateOperation);
                }

                return sr.NextId;

            }
            catch (Exception e)
            {
                LogFactory.GetLogger().Log(LogLevel.Error, e);
                return 0;
            }
            finally
            {
                SequenceGeneratorSemaphore.semaphoreSlim.Release();
            }

        }
    }


    public static class SequenceGeneratorSemaphore
    {
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    }


    public class SequenceRecord
    {
        public string Table { get; set; }

        public int NextId { get; set; }

        public int SaveId { get; set; }
    }



    public class Counter : TableEntity
    {
        public Counter(string table)
        {
            this.Table = table;
            this.RowKey = table;

            this.PartitionKey = "default";
        }

        public Counter()
        {
            
        }

        public string Table { get; set; }

        public int CurrentCounter { get; set; }

    }
}
