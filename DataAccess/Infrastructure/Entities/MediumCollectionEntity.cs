using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class MediumCollectionEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        [JsonPropertyName("MusikträgerId")]
        public int StorageMediaId { get; set; }
        public int MediumId { get; set; }
        [JsonPropertyName("TitelcollectionId")]
        public int? TitleCollectionId { get; set; }
        public string Type { get; set; } = string.Empty;

        public MediumCollectionEntity()
        {
        }

        internal MediumCollectionEntity(int? id, int storageMediaId, int mediumId, int? titleCollectionId, string type)
        {
            Id = id;
            StorageMediaId = storageMediaId;
            MediumId = mediumId;
            TitleCollectionId = titleCollectionId;
            Type = type;
        }
    }
}
