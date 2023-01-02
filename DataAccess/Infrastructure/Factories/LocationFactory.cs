using DataAccess.Infrastructure.AbstractClasses;
using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Entities.Helper;
using DataAccess.Infrastructure.Enums;
using DataAccess.Infrastructure.Extensions;
using DataAccess.Infrastructure.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Factories
{
    public sealed class LocationFactory : EntityFactory<LocationEntity>
    {
        protected internal override string controller => "locations/";

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

        public LocationFactory(Uri baseUri) : base(baseUri)
        {
        }
    }
}
