using CityInfo.API.Model;
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

        [HttpGet("{cityId}/pointsofinterest/{interestId}", Name = "getPointOfInterest")]
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
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOdInterest(int cityId, [FromBody] PointOfInterestCreateDto pointOfInterestCreateDto)
        {
            if (pointOfInterestCreateDto == null)
            {
                return BadRequest();
            }

            if (pointOfInterestCreateDto.Description == pointOfInterestCreateDto.Name)
            {
                ModelState.AddModelError("Description", "Description cannot be the same as name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var newId = CitiesDataStore.citiesDataStore.Cities.SelectMany(x => x.PointsOfInterest).Max(x => x.Id) + 1;
            var newPointOfInterest = new PointOfInterestDto()
            {
                Id = newId,
                Name = pointOfInterestCreateDto.Name,
                Description = pointOfInterestCreateDto.Description
            };

            city.PointsOfInterest.Add(newPointOfInterest);

            return CreatedAtRoute("getPointOfInterest", new { cityId = city.Id, interestId = newId }, newPointOfInterest);

        }
    }
}
