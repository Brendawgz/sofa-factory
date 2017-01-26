using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SofaFactory.Models
{
    public class Sofa
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        public string Material { get; set; }

        public string Features { get; set; }

        public string Description { get; set; }

        public double OriginalPrice { get; set; }

        public double Price { get; set; }

        public string SaleImagePath { get; set; }
        public string MeasurementImagePath { get; set; }
        public string ConfigurationImagePath { get; set; }
    }
}
