using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema_C4.Models
{
    public enum CarBody
    {
        Sedan,
        Hatchback,
        SUV,
        Coupe,
        Pickup,
        Convertible
    }
    public class CarsClass
    {
        public int Id { get; set; } 
        public string Maker { get; set; }
        public string Model { get; set; }
        public CarBody CarBody { get; set; }
        public DateTime Year { get; set; }
        public int HorsePower { get; set; }     

    }
}
