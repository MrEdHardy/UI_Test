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
    public sealed class TitleCollectionFactory : EntityFactory<TitleCollectionEntity>
    {

        protected internal override string controller { get => "artists/"; }

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
        public TitleCollectionFactory(Uri baseUri) : base(baseUri)
        {
        }
    }
}
