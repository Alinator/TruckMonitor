using System;
using TruckStatusUpdater.Models;

namespace TruckStatusUpdater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            customerDatabaseContext context = new customerDatabaseContext();
            TruckConnector truckConnector = new TruckConnector(context);

            truckConnector.getAllTrucksAndUpdateTruckStatus();
        }
    }
}
