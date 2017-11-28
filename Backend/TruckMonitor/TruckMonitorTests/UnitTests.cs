using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FluentAssertions;
using TruckAPI.Models;
using TruckAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using TruckStatusUpdater;

namespace TruckMonitorTests
{
    public class UnitTests : IDisposable
    {
        private readonly customerDatabaseContext _context;

        public UnitTests()
        {
            // we will supply a new service provider for each context,
            // that will enable us to have a single database instance per test.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Build context options
            var builder = new DbContextOptionsBuilder<customerDatabaseContext>()
                .UseInMemoryDatabase("customerDatabase")
                .UseInternalServiceProvider(serviceProvider);

            _context = new customerDatabaseContext(builder.Options);
            _context.CustomerTrucks.AddRange(
                Enumerable.Range(1, 10)
                .Select(t => new CustomerTrucks
                {
                    VehicleId = "vehicleID" + t,
                    CustomerCompanyName = "customerCompanyName" + t,
                    Adress = "adressssss" + t,
                    RegNr = "RegNR" + t,
                    TruckConnectionStatus = "iThinkItsConnected" + t
                })
                );

            _context.SaveChanges();

        }

        [Fact]
        public void getAllFromTrucksControllerShouldReturnAllTrucksInJsonFormat()
        {
            //arrange
            var controller = new TrucksController(_context);
            //act
            var result = controller.GetAll();

            Console.WriteLine(result.Value);
            Console.Read();
            //assert
            result.Should().BeOfType<JsonResult>("Because result should be a jsonResult");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
