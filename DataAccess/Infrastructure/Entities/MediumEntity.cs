using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class MediumEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        [JsonPropertyName("B-Seite")]
        public bool? HasBSide { get; set; }
        public int? LocationId { get; set; }

        public MediumEntity()
        {
        }

        internal MediumEntity(int? id, bool? hasBSide, int? locationId)
        {
            Id = id;
            HasBSide = hasBSide;
            LocationId = locationId;
        }
    }
}
