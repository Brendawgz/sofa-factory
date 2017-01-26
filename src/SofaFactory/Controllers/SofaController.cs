using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SofaFactory.Data;
using Microsoft.EntityFrameworkCore;
using SofaFactory.Models;

namespace SofaFactory.Controllers
{
    public class SofaController : Controller
    {
        private readonly List<Sofa> sofas = new List<Sofa>()
            {
                new Sofa() {Id = 1, ProductCode = "M-9968", Material = "Full Leather", Features = "2 Recliner Chairs + \n3 Seater/2 Recliners", Price = 2790, OriginalPrice = 3970, SaleImagePath = @"~/images/sales/m-9968.png", MeasurementImagePath = @"~/images/measurements/m-9968_measurements.png"},
                new Sofa() {Id = 2, ProductCode = "M-9369", Material = "Full Leather", Features = "3Seaters/3Electric \nIncliners + Teaboy", Price = 2750, OriginalPrice = 3950, SaleImagePath = @"~/images/sales/m-9369.png", MeasurementImagePath = @"~/images/measurements/m-9369_measurements.png"},
                new Sofa() {Id = 3, ProductCode = "M-9928", Material = "Full Leather", Features = "2 Recliner Chairs + \n3 Seater/2 Recliners", Price = 2990, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9928.png", MeasurementImagePath = @"~/images/measurements/m-9928_measurements.png"},
                new Sofa() {Id = 4, ProductCode = "M-9911", Material = "Full Leather", Features = "2 Recliner Chairs + \n3 Seater/2 Recliners", Price = 2870, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9911.png", MeasurementImagePath = @"~/images/measurements/m-9911_measurements.png"},
                new Sofa() {Id = 5, ProductCode = "M-9922", Material = "Full Leather", Features = "2 Recliner Chairs + \n2.5 Seater/2 Recliners", Price = 2890, OriginalPrice = 4250, SaleImagePath = @"~/images/sales/m-9922.png", MeasurementImagePath = @"~/images/measurements/m-9922_measurements.png"},
                new Sofa() {Id = 6, ProductCode = "M-9918", Material = "Full Leather", Features = "2 Recliner Chairs + \n3 Seater/2 Recliners", Price = 2890, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9918.png", MeasurementImagePath = @"~/images/measurements/m-9918_measurements.png"},
                new Sofa() {Id = 7, ProductCode = "M-9919", Material = "Full Leather", Features = "2 Recliner Chairs + \n2.5 Seater/2 Recliners", Price = 2950, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9919.png", MeasurementImagePath = @"~/images/measurements/m-9919_measurements.png"},
                new Sofa() {Id = 8, ProductCode = "M-9902", Material = "Full Leather", Features = "2 Recliner Chairs + \n3 Seater/2 Recliners", Price = 2890, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9902.png", MeasurementImagePath = @"~/images/measurements/m-9902_measurements.png"},
                new Sofa() {Id = 9, ProductCode = "M-9932 Home Theatre", Material = "Full Leather", Features = "4 Electric Recliners \n4 Console Arms", Price = 2990, OriginalPrice = 3990, SaleImagePath = @"~/images/sales/m-9932_home_theatre.png", MeasurementImagePath = @"~/images/measurements/m-9932_home_theatre_measurements.png"},
                new Sofa() {Id = 10, ProductCode = "M-9868", Material = "Full Leather", Features = "2 Seaters + \n3 Seaters", Price = 2850, OriginalPrice = 3650, SaleImagePath = @"~/images/sales/m-9868.png", MeasurementImagePath = @"~/images/measurements/m-9868_measurements.png"},
                new Sofa() {Id = 11, ProductCode = "M-9903", Material = "Full Leather", Features = "Corner Set \nAdjustable Head Rest \n& E. Recliner", Price = 3750, OriginalPrice = 4990, SaleImagePath = @"~/images/sales/m-9903.png", MeasurementImagePath = @"~/images/measurements/m-9903_measurements.png"},
                new Sofa() {Id = 12, ProductCode = "M-8363", Material = "Full Leather", Features = "2 Seaters + \n2.5 Seaters", Price = 2850, OriginalPrice = 3650, SaleImagePath = @"~/images/sales/m-8363.png", MeasurementImagePath = @"~/images/measurements/m-8363_measurements.png"},
                new Sofa() {Id = 13, ProductCode = "M-7745", Material = "Full Leather", Features = "Corner Set \nWithout Stool", Price = 2790, OriginalPrice = 3450, SaleImagePath = @"~/images/sales/m-7745.png", MeasurementImagePath = @"~/images/measurements/m-7745_measurements.png"},
                new Sofa() {Id = 14, ProductCode = "M-9968", Material = "Full Leather", Features = "3 Electric Recliners + \nChaise + Console", Price = 2990, OriginalPrice = 3950, SaleImagePath = @"~/images/sales/m-9968_2.png", MeasurementImagePath = @"~/images/measurements/m-9968_2_measurements.png"},
                new Sofa() {Id = 15, ProductCode = "M-228", Material = "Full Leather", Features = "Corner Set \nAdjustable Headrests And \nSeats", Price = 3050, OriginalPrice = 4250, SaleImagePath = @"~/images/sales/m-228.png", MeasurementImagePath = @"~/images/measurements/m-228_measurements.png"},
                new Sofa() {Id = 16, ProductCode = "M-1688", Material = "Full Leather", Features = "L-shape 2.5 Seater \n + Corner/Chaise", Price = 2250, OriginalPrice = 3150, SaleImagePath = @"~/images/sales/m-1688.png", MeasurementImagePath = @"~/images/measurements/m-1688_measurements.png"},
                new Sofa() {Id = 17, ProductCode = "M-399", Material = "Full Leather", Features = "Corner Set \nAdjustable Headrests & \nExtendable Seaters", Price = 4290, OriginalPrice = 5850, SaleImagePath = @"~/images/sales/m-399.png", MeasurementImagePath = @"~/images/measurements/m-399_measurements.png"}
            };

        private readonly List<Sofa> samples = new List<Sofa>()
            {
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_1.png"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_2.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_3.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_4.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_5.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_6.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_7.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_8.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_9.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_10.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_11.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_12.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_13.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_14.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_15.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_16.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_17.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_18.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_19.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_20.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_21.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_22.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_23.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_24.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_25.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_26.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_27.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_28.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_29.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_30.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_31.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_32.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_33.JPG"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_34.png"},
                new Sofa() {ConfigurationImagePath = @"~/images/samples/sample_35.JPG"}
            };

        public IActionResult Index()
        {
            return View(sofas);
        }

        public IActionResult Measurement(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(sofas.SingleOrDefault(s => s.Id == id));
        }

        public IActionResult Samples()
        {
            return View(samples);
        }
    }
}
