using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public sealed class StorageMediaEntity
    {
        [JsonInclude]
        public int? Id { get; private set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        [JsonPropertyName("Kaufdatum")]
        public DateTime BuyDate { get; set; }

        public StorageMediaEntity()
        {
            Name = string.Empty;
            Genre = string.Empty;
            BuyDate = DateTime.MinValue;
        }

        internal StorageMediaEntity(int? id, string name, string genre, DateTime buyDate)
        {
            Id = id;
            Name = name;
            Genre = genre;
            BuyDate = buyDate;
        }
    }
}
