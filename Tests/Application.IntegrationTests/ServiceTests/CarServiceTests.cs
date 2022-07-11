using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
 

    public class CarServiceTests : TestBase
    {

        public CarServiceTests()
        {
            UseSqlite();
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            Assert.False(true);

        }

    }
}
