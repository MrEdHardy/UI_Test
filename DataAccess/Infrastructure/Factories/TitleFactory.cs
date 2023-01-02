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
    public class TitleFactory : EntityFactory<TitleEntity>
    {
        public TitleFactory(Uri baseUri) : base(baseUri)
        {
        }

        protected internal override string controller => "titles/";

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
