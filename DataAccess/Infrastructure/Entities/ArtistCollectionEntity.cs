using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class ArtistCollectionEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        [JsonPropertyName("KünstlerId")]
        public int ArtistId { get; set; }
        [JsonPropertyName("MusikträgerId")]
        public int StorageMediaId { get; set; }

        public ArtistCollectionEntity()
        {
        }

        internal ArtistCollectionEntity(int? id, int artistId, int storageMediaId)
        {
            Id = id;
            ArtistId = artistId;
            StorageMediaId = storageMediaId;
        }
    }
}
