using System;
using System.Collections.Generic;
using System.Text;
using TruckStatusUpdater.Models;

namespace TruckStatusUpdater
{
    public class TruckConnector
    {
        private readonly customerDatabaseContext _context;
        public string[] connectionString = { "connected","connection lost"};

        public TruckConnector(customerDatabaseContext context)
        {
            _context = context;
        }

        public void getAllTrucksAndUpdateTruckStatus()
        {
            using (_context)
            {
                foreach (var truck in _context.CustomerTrucks)
                {
                    string truckConnectionStatus = pingTruck(truck.VehicleId);
                    updateTruckStatus(truck, truckConnectionStatus);
                }

                _context.SaveChanges();
            }
        }
        /**
         *  Here in the real scenario, we would through a network request
         *  ping a certain truck that we recieve as a parameter from the customer
         *  database.
         *  However here im only randomly selecting a value from the connectionString array
         *  to simulate a ping.
         * */
        private string pingTruck(string vehicleID)
        {
            string vehicleStatus = connectionString[new Random().Next(0, connectionString.Length)];
            return vehicleStatus;
        }

        private void updateTruckStatus(CustomerTrucks truck, string truckConnectionStatus)
        {
            truck.TruckConnectionStatus = truckConnectionStatus;
        }
    }
}
