using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class ArtistEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        public string Name { get; set; }

        public ArtistEntity()
        {
        }

        internal ArtistEntity(int? id, string name = null)
        {
            Id = id;
            Name = name;
        }
    }
}
