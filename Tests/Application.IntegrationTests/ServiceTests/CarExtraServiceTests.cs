using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarExtraServiceTests : TestBase
    {

        public CarExtraServiceTests()
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
