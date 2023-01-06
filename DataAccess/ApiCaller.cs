using System;
using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Enums;
using RestSharp;
using System.Text.Json;
using System.Text;
using System.Net;
using System.Threading.Tasks;

internal static class ApiCaller
{
    private static readonly Lazy<RestClient> lazy = new Lazy<RestClient>(() => new RestClient());

    internal static RestClient RestClientInstance { get { return lazy.Value; } }

    internal async static Task<T> Call<T>(Uri urlToApiEndpoint, ApiCallType callType, Method httpMethod, string queryField = null, string queryFieldValue = null, string jsonBody = null)
        where T : class
    {
        RestClientInstance.Options.BaseUrl = urlToApiEndpoint;
        var request = new RestRequest();
        request.Method = httpMethod;

        if (callType == ApiCallType.Id)
        {
            request.AddQueryParameter("Id", queryFieldValue);
        }
        else if (callType == (ApiCallType.Id | ApiCallType.JSON))
        {
            if (string.IsNullOrEmpty(queryFieldValue) && string.IsNullOrEmpty(jsonBody))
            {
                throw new ArgumentNullException("Id or JSON cant be null!");
            }

            if (string.IsNullOrEmpty(jsonBody))
            {
                request.AddQueryParameter("Id", queryFieldValue);
            }
            else
            {
                request.AddBody(jsonBody, "application/json");
            }
        }
        else if (callType == (ApiCallType.Id | ApiCallType.CustomSimpleField))
        {
            if (string.IsNullOrEmpty(queryField) && string.IsNullOrEmpty(queryFieldValue))
                throw new ArgumentNullException(queryField);
            var query = queryField ?? string.Empty;
            request.AddQueryParameter(string.Equals(query, "Name") ? query : "Id", queryFieldValue);
        }
        else if (callType == (ApiCallType.Id & ApiCallType.JSON))
        {
            if (string.IsNullOrEmpty(jsonBody))
                throw new ArgumentNullException(jsonBody);
            request.AddQueryParameter("Id", queryFieldValue);
            request.AddBody(jsonBody, "application/json");
        }
        else if (callType == ApiCallType.CustomSimpleField)
        {
            if (string.IsNullOrEmpty(queryField))
                throw new ArgumentNullException(queryField);
            request.AddQueryParameter(queryField, queryFieldValue);
        }
        else if (callType == ApiCallType.JSON)
        {
            if (string.IsNullOrEmpty(jsonBody))
                throw new ArgumentNullException(jsonBody);
            request.AddBody(jsonBody, "application/json");
        }

        var response = await RestClientInstance.ExecuteAsync(request);
        object result = new object();

        if (response.IsSuccessful)
        {
            result = JsonSerializer.Deserialize<T>(response.Content ?? "[{}]") ?? new object();
        }
        else
        {
            //result = new object();
            throw new Exception(response.Content);
        }

        return (T)result;
    }


}
