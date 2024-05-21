using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.DTOs
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholPercentage { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}
