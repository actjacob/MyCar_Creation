using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar_Creation.Context;
using MyCar_Creation.Dtos;
using MyCar_Creation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCar_Creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult CreateVehicle(VehicleDTO model)
        {

            Vehicle vehicle = new()
            {
                Brand = model.Brand,
                Model = model.Model,
                ModelYear = model.ModelYear,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };//Maplemek
            _context.Vehicles.Add(vehicle);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{VehicleId}")]
        public ActionResult DeleteVehicle([FromRoute] Guid VehicleId)
        {
            Vehicle Vehicle = _context.Vehicles.Find(VehicleId);
            if (Vehicle is not null)
            {
                _context.Vehicles.Remove(Vehicle);
                if (_context.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult GetAllVehicle()
        {
            List<Vehicle> Vehicles = _context.Vehicles.ToList();
            if (Vehicles is not null)
            {
                return Ok(Vehicles);
            }
            return NotFound();
        }
        [HttpPut]
        public ActionResult UpdateVehicle([FromRoute] Guid VehicleId, VehicleDTO model)
        {
            Vehicle Vehicle = _context.Vehicles.Find(VehicleId);
            if (Vehicle is not null)
            {
                return Ok(Vehicle);
            }
            return NotFound();
        }


        [HttpGet("{vehicleId}")]
        public ActionResult GetVehiclyById(Guid vehicleId)
        { 
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle is not null)
            {
                return Ok(vehicle); 
            }
            return NotFound();

        }



        [HttpGet("{categoryId}")]
        public ActionResult GetVehicleByCategoryId([FromRoute] Guid categoryId)
        {
            List<Vehicle> vehicles = _context.Vehicles.Where(x => x.CategoryId == categoryId).ToList();
            if (vehicles is not null)
            {
                return Ok(vehicles);
            }
            return NotFound();
            

        }
    }
}
