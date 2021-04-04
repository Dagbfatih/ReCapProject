using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDetailDto:IDto
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImageDate { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
    }
}
