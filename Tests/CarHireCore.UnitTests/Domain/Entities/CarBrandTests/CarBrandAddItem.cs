using Domain.Entities.CarBrandsAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHireCore.UnitTests.Domain.Entities.CarBrandTests
{
    public class CarBrandAddItem
    {

        private readonly string _testCarBrandName = "ABC";
        
        [Test]
        public void AddsCarBrandIfNotPresent()
        {
            var carBrand = new CarBrand() { Name = "ABC" };

            Assert.AreEqual(_testCarBrandName, carBrand.Name);
           
        }

    }
}
