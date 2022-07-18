using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{

    using static TestingCqrs;

    public class TestBaseCqrs
    {
        [SetUp]
        public async Task SetUp()
        {
            await ResetState();
        }
    }
    
}
