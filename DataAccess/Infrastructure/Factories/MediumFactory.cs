using DataAccess.Infrastructure.AbstractClasses;
using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Enums;
using DataAccess.Infrastructure.Extensions;
using DataAccess.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Factories
{
    public sealed class MediumFactory : EntityFactory<MediumEntity>
    {
        public MediumFactory(Uri baseUri) : base(baseUri)
        {
        }

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

        protected internal override string controller => "media/";
    }
}
