using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Domain.Entities
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BeerSale> BeerSales { get; set; }
    }


}
