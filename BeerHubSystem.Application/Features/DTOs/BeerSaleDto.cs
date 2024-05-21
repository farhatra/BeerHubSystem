using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.DTOs
{
    public class BeerSaleDto
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public int WholesalerId { get; set; }
        public int Quantity { get; set; }
        public decimal FixedPrice { get; set; }
    }

}
