using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parliament.JargonBuster.AdminApp.Tests.MockBuilders
{
    public class MockDefinitionBuilder
    {
        private readonly Definition _entity;

        public MockDefinitionBuilder()
        {
            _entity = new Definition();
        }
    }
}
