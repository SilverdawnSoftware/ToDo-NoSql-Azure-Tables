using System;
using FluentAssertions;
using Microsoft.WindowsAzure.Storage.Table;
using ToDo.Database;
using Xunit;

namespace ToDo.Tests
{
    public class SequenceGeneratorTests
    {
        [Fact]
        public async void Test1()
        {
            var result = await Sequence.SequenceGenerator.GetNextId("Test");

            result.Should().BeGreaterThan(0);
        }


        [Fact]
        public async void TestCounterUpdated()
        {


            var counterTable = await Utils.GetTable(SequenceGenerator.CounterTableName);

            Counter startCounter = new Counter("Test");
            Counter endCounter = new Counter("Test");
            var getCounter = TableOperation.Retrieve<Counter>("default", "Test");
            var result = await counterTable.ExecuteAsync(getCounter);

            //load and update existing record
            if (result.Result != null)
            {
                startCounter = (Counter) result.Result;
            }


            for (int i = 0; i < 110; i++)
            {
                var temp = await Sequence.SequenceGenerator.GetNextId("Test");
            }



            var result2 = await counterTable.ExecuteAsync(getCounter);

            //load and update existing record
            if (result2.Result != null)
            {
                endCounter = (Counter) result2.Result;
            }


            endCounter.Should().NotBeNull();
            startCounter.Should().NotBeNull();
            endCounter?.CurrentCounter.Should().BeGreaterThan(startCounter.CurrentCounter);
        }


    }

}

