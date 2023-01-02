using DataAccess.Infrastructure.AbstractClasses;
using DataAccess.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Factories
{
    public class MediumCollectionFactory : EntityFactory<MediumCollectionEntity>
    {
        public MediumCollectionFactory(Uri baseUri) : base(baseUri)
        {
        }

        protected internal override string controller => "mediumcollection/";

        internal override JsonSerializerOptions serializerOptions
        {
            get
            {
                return new JsonSerializerOptions()
                {
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                };
            }
        }
    }
}
