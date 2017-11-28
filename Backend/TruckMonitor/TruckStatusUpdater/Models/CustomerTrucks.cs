using System;
using System.Collections.Generic;

namespace TruckStatusUpdater.Models
{
    public partial class CustomerTrucks
    {
        public string VehicleId { get; set; }
        public string CustomerCompanyName { get; set; }
        public string Adress { get; set; }
        public string RegNr { get; set; }
        public string TruckConnectionStatus { get; set; }
    }
}
