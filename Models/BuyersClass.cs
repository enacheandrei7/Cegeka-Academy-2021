using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema_C4.Models
{
    public class BuyersClass
    {
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BoughtCarId { get; set; }
        public string Maker { get; set; }
        public string ModelBought { get; set; }
        public DateTime Year { get; set; }
    }
}
