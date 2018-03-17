using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            if (!CitiesDataStore.citiesDataStore.Cities.Any(x => x.Id == cityId))
            {
                return NotFound();
            }

            return Ok(CitiesDataStore.citiesDataStore.Cities.First(x => x.Id == cityId).PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{interestId}")]
        public IActionResult GetPointOfInterest(int cityId, int interestId)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOdInterest = city.PointsOfInterest.FirstOrDefault(x => x.Id == interestId);

            if (pointOdInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOdInterest);
        }
    }
}
