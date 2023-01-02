using DataAccess.Infrastructure.AbstractClasses;
using DataAccess.Infrastructure.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Extensions
{
    internal static class EntityFactoryExtensions
    {
        internal static Uri GetPathToControllerAction<T>(this EntityFactory<T> factory, string controllerAction)
            where  T : class
        {
            return new Uri(factory.pathToController, controllerAction.ToString());
        }

        internal async static Task<List<T>> GetAllEntities<T>(this EntityFactory<T> factory, Uri pathToAction)
            where T : class
        {
            return await ApiCaller
                .Call<List<T>>(pathToAction, ApiCallType.Simple, Method.Get, null, null, null); ;
        }

        internal async static Task<List<T>> GetEntityByParam<T>(this EntityFactory<T> factory, Uri pathToAction, ApiCallType callType, string queryfieldValue, string queryfield = null)
            where T : class
        {
            return await ApiCaller
                .Call<List<T>>(pathToAction, callType, Method.Get, queryfield, queryfieldValue, null); ;
        }

        internal async static Task<T> AddEntity<T>(this EntityFactory<T> factory, Uri pathToAction, T entity)
            where T : class
        {
            var serializedEntity = JsonSerializer.Serialize(entity, factory.serializerOptions);
            var result = await ApiCaller.Call<T>
                (pathToAction, ApiCallType.JSON, Method.Put, null, null, serializedEntity);
            return result;
        }

        internal async static Task UpdateEntity<T>(this EntityFactory<T> factory, Uri pathToAction, T entity, int id)
            where T : class
        {
            var serializedEntity = JsonSerializer.Serialize(entity, factory.serializerOptions);
            await ApiCaller.Call<object>
                (pathToAction, (ApiCallType.JSON & ApiCallType.Id), Method.Post, null, id.ToString(), serializedEntity);
        }

        internal async static Task DeleteEntity<T>(this EntityFactory<T> factory, Uri pathToAction, ApiCallType callType, string queryFieldValue, string queryField = null)
            where T: class
        {
            await ApiCaller.Call<object>
                (pathToAction, callType, Method.Delete, queryFieldValue, queryField, null);
        }
    }
}
