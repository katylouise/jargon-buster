//using Parliament.JargonBuster.AdminApp.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Parliament.JargonBuster.AdminApp.Tests.MockBuilders
//{
//    public class MockDefinitionBuilder
//    {
//        private readonly DefinitionItem _entity;

//        public MockDefinitionBuilder()
//        {
//            _entity = new DefinitionItem();
//        }

//        public MockDefinitionBuilder DefaultDefinitionEntity()
//        {
//            _entity.Id = 123;
//            _entity.Phrase = "test";
//            _entity.Definition = "test definition";
//            _entity.Alternates = new List<AlternateDefinitionItem>();
//            return this;
//        }

//        public MockDefinitionBuilder Id(int id)
//        {
//            _entity.Id = id;
//            return this;
//        }

//        public MockDefinitionBuilder Phrase(string phrase)
//        {
//            _entity.Phrase = phrase;
//            return this;
//        }

//        public MockDefinitionBuilder Definition(string definition)
//        {
//            _entity.Definition = definition;
//            return this;
//        }

//        public MockDefinitionBuilder Alternate(AlternateDefinitionItem alternate)
//        {
//            _entity.Alternates.Add(alternate);
//            return this;
//        }

//        public virtual DefinitionItem Build()
//        {
//            return _entity;
//        }

//    }
//}
