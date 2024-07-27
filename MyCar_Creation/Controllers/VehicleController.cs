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
            };
            //Maplemek
             _context.Vehicles.Add(vehicle);

            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{vehicleId}")]
        public ActionResult DeleteVehicle([FromRoute] Guid vehicleId)
        {
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle is not null)
            {
                _context.Vehicles.Remove(vehicle);
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
            List<Vehicle> categories = _context.Vehicles.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return NotFound();
        }



        [HttpPut("{vehicleId}")]
        public ActionResult UpdateVehicle([FromRoute] Guid vehicleId, VehicleDTO model)
        {
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle is not null)
            {
                vehicle.Price = model.Price;
                vehicle.Description = model.Description;
                vehicle.CategoryId = model.CategoryId;
                vehicle.Brand = model.Brand;
                vehicle.Model = model.Model;
                vehicle.ModelYear = model.ModelYear;
                if (_context.SaveChanges() > 0)
                {
                    return Ok(model);
                }

            }
            return NotFound();
        }


        [HttpGet("{vehicleId}")]
        public ActionResult GetVehicleById([FromRoute] Guid vehicleId)
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
