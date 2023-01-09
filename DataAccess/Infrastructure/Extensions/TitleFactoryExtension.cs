using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Enums;
using DataAccess.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Extensions
{
    public static class TitleFactoryExtension
    {
        public static async Task<IEnumerable<TitleEntity>> GetAllByArtistId(this TitleFactory titleFactory, int value)
        {
            return await titleFactory.GetEntityByParam(titleFactory.GetPathToControllerAction(titleFactory.actionPathDefinitions["getallbyartistid"]), ApiCallType.Id, value.ToString());
        }
    }
}
