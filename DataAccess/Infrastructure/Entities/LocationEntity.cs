using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class LocationEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        [JsonPropertyName("Regal")]
        public int? Shelf { get; set; }
        [JsonPropertyName("Etage")]
        public int? Level { get; set; }
        [JsonPropertyName("Stelle")]
        public int? Position { get; set; }
        [JsonPropertyName("Active")]
        public bool? IsActive { get; set; }

        public LocationEntity()
        {
        }

        internal LocationEntity(int? id, int? shelf, int? level, int? position, bool? isActive)
        {
            Id = id;
            Shelf = shelf;
            Level = level;
            Position = position;
            IsActive = isActive;
        }
    }
}
