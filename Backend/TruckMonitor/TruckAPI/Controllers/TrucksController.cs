using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruckAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace TruckAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class TrucksController : Controller
    {
        private readonly customerDatabaseContext _context;
        public TrucksController(customerDatabaseContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public JsonResult GetAll()
        {
            Customers customers = new Customers();
            using (_context)
            {
                foreach (var truck in _context.CustomerTrucks)
                {
                    customers.customerTrucks.Add(truck);
                }
            }
            JsonResult result = new JsonResult(customers);
            return result;
        }
    }
}
