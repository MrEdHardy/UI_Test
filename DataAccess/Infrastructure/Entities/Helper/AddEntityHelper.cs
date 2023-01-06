using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Entities.Helper
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    internal sealed class AddEntityHelper
    {
        [JsonInclude]
        public int Id { get; private set; }
    }
}
