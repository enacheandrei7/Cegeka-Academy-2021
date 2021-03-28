using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tema_C4.Models;

namespace Tema_C4.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CarsController : ControllerBase
     {
         public static List<CarsClass> _cars = new List<CarsClass>()
            {
                new CarsClass()
                { 
                    Id = 1,
                    Maker = "Dacia",
                    Model = "Stepway",
                    CarBody = CarBody.Hatchback,
                    Year = new DateTime(2010, 06, 22),
                    HorsePower = 200
                },
                new CarsClass()
                {
                    Id = 2,
                    Maker = "Volkswagen",
                    Model = "Tiguan",
                    CarBody = CarBody.SUV,
                    Year = new DateTime(2018, 09, 27),
                    HorsePower = 300
                }
            };

         [HttpGet]
         public IActionResult GetAllCars() //with api/cars in GET we will see all the models
         {
             return Ok(_cars);
         }

         [HttpGet]
         [Route("car/{id}")]
         public IActionResult GetCarById(int id)   //with api/cars/car/{id} in GET we can see the car stats of each selected model
        {
            return Ok(_cars.FirstOrDefault(x => x.Id == id)); 
        }


        [HttpPost]  // api/cars  -- here we can add a new car ( id must be !=0, the request must have an existing model and the id should be unique)
        public IActionResult CreateNewCar([FromBody] CarsClass model)
         {
            if (model.Model == null )
            {
                return BadRequest("Please insert a model");
            }
            else if (model.Id == 0)
            {
                return BadRequest("Please insert an id different from 0");
            }
            var car = _cars.FirstOrDefault(x => x.Id == model.Id);
            if(car == null)
            {
                _cars.Add(model);     
            }
            else 
            {
                return BadRequest("The current id is already in use, please insert another id");
            }

            return Ok(model);
         }

        [HttpPut] // api/cars/car/{id} -- Here we change an existing car
        [Route("car/{id}")]
        public IActionResult UpdateCar(int id, [FromBody] CarsClass model)
        {
            if (model.Model == null)
            {
                return BadRequest();
            }

            var car = _cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            car.Model = model.Model;
            car.Year = model.Year;

            return Ok(car);
        }

        [HttpDelete] //here we can delete an existing car
        [Route("car/{id}")]

        public IActionResult RemoveCar (int id)
        {
            if (id <- 0)
            {
                return BadRequest();
            }

            var car = _cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            _cars.Remove(car);

            return Ok(car);
        }
    }


    
}
