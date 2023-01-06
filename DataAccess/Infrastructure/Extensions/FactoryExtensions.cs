using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Entities.Helper;
using DataAccess.Infrastructure.Enums;
using DataAccess.Infrastructure.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Extensions
{
    internal static class FactoryExtensions
    {
        internal static Uri GetPathToControllerAction<T>(this IEntityFactory<T> factory, Uri pathToController, ReadOnlySpan<char> controllerAction)
        {
            return new Uri(pathToController, controllerAction.ToString());
        }

        internal async static Task<List<T>> GetAllEntities<T>(this IEntityFactory<T> factory, Uri pathToAction)
        {
            var result = await ApiCaller.Call<List<T>>
                (pathToAction, ApiCallType.Simple, Method.Get, null, null, null);
            return result;
        }

        internal async static Task<List<T>> GetEntityByParam<T>(this IEntityFactory<T> factory, Uri pathToAction, ApiCallType callType, string queryfield, string queryfieldValue)
        {
            var result = await ApiCaller
                .Call<List<T>>(pathToAction, callType, Method.Get, queryfield, queryfieldValue, null);
            return result;
        }

        internal async static Task<T> AddEntity<T>(this IEntityFactory<T> factory, Uri pathToAction, JsonSerializerOptions serializerOptions, T entity)
            where T : class
        {
            var serializedEntity = JsonSerializer.Serialize(entity, serializerOptions);
            var result = await ApiCaller.Call<T>
                (pathToAction, ApiCallType.JSON, Method.Put, null, null, serializedEntity);
            return result;
        }

        internal async static Task UpdateEntity<T>(this IEntityFactory<T> factory, Uri pathToAction, JsonSerializerOptions serializerOptions, T entity, int id)
        {
            var serializedEntity = JsonSerializer.Serialize(entity, serializerOptions);
            await ApiCaller.Call<object>
                (pathToAction,(ApiCallType.JSON & ApiCallType.Id), Method.Post, null, id.ToString(), serializedEntity);
        }

        internal async static Task DeleteEntity<T>(this IEntityFactory<T> factory, Uri pathToAction, ApiCallType callType, string queryField, string queryFieldValue)
        {
            await ApiCaller.Call<object>
                (pathToAction, callType, Method.Delete, queryField, queryFieldValue, null);
        }
    }
}
