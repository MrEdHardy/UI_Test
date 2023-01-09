using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class TitleCollectionEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        [JsonPropertyName("TitelId")]
        public int TitleId { get; set; }
        [JsonPropertyName("KünstlerId")]
        public int ArtistId { get; set; }

        public TitleCollectionEntity()
        {
        }

        public TitleCollectionEntity(int? id, int titleId, int artistId)
        {
            Id = id;
            TitleId = titleId;
            ArtistId = artistId;
        }
    }
}
