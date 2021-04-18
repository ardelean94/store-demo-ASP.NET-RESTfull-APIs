using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store_demo.Dto
{
    //use DTO for avoid displaying implementation detail (domain model)
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public long Quantity { get; set; }

        public float Price { get; set; }
    }
}