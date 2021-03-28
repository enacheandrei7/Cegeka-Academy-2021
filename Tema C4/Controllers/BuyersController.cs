using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema_C4.Models;
using static Tema_C4.Controllers.CarsController;

namespace Tema_C4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        public static List<BuyersClass> _buyers = new List<BuyersClass>()
        {
            new BuyersClass()
            {
                BuyerId = 1,
                FirstName = "Andrei",
                LastName = "Enache",
                BoughtCarId = 1,
                Maker = "Dacia",
                ModelBought = "Stepway",
                Year = CarsController._cars[0].Year

            },
                        new BuyersClass()
            {
                BuyerId = 2,
                FirstName = "Bogdan",
                LastName = "Pavel",
                BoughtCarId = 2,
                Maker = "Mercedes",
                ModelBought = "Benz",
                Year = CarsController._cars[1].Year

            }
        };

            [HttpGet]
            public IActionResult GetAllBuyers() //with api/buyers -- GET -- we will see all the buyers
            {
                return Ok(_buyers);
            }

            [HttpPost]  // api/buyers  -- POST -- here we can add a new buyer ( buyerId must be !=0 and unique, boughtCarId must be valid, from the cars list)
            public IActionResult CreateNewBuyer([FromBody] BuyersClass Buyer)
            {

                if (Buyer.BuyerId == 0)
                {
                    return BadRequest("The owner ID must be different from 0");
                }
                else if (Buyer.BoughtCarId == 0)
                {
                    return BadRequest("Invalid car ID");
                }
                else if (Buyer.FirstName == null)
                {
                    return BadRequest("Please enter a firstName");
                }
                else if (Buyer.LastName == null)
                {
                    return BadRequest("Please enter a lasttName");
                }
                var buyer = _buyers.FirstOrDefault(x => x.BuyerId == Buyer.BuyerId);
                if (buyer == null)
                {
                    var boughtCar = _cars.FirstOrDefault(x => x.Id == Buyer.BoughtCarId);
                    if (boughtCar == null)
                    {
                        return BadRequest("The selected boughtCarId was not found in our list, please try again with the id of an existing car");
                    }
                    else
                    {
                        var boughtCarMaker = boughtCar.Maker;
                        Buyer.Maker = boughtCarMaker;
                        var boughtCarModel = boughtCar.Model;
                        Buyer.ModelBought = boughtCarModel;
                        var boughtCarYear = boughtCar.Year;
                        Buyer.Year = boughtCarYear;
                        _buyers.Add(Buyer);
                    }
                }
                else
                {
                    return BadRequest("The current buyerid is already in use");
                }


                return Ok(Buyer);
            }

    }
}
