using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Model
{
    public class PointOfInterestCreateDto
    {
        [Required(ErrorMessage = "Required field")]
        [MaxLength(50, ErrorMessage = "Name max 50 chars")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        [MaxLength(200, ErrorMessage = "Name max 200 chars")]
        public string Description { get; set; }
    }
}
