using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Domain.Entities
{
    public class BeerSale
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public int Quantity { get; set; }
        public decimal FixedPrice { get; set; }
    }


}
