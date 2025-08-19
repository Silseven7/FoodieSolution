using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Shared.Services;
using System.Net.Http.Json;

namespace Foodie.Client.Services
{
    public class ClientBaseService<TModel> : IServiceBase<TModel> where TModel : class, new()
    {
        private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7056") };

        public async Task<TModel> AddAsync(TModel entity)
        {
            var response = await _http.PostAsJsonAsync($"api/{typeof(TModel).Name}/AddAsync", entity);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TModel>() ?? new TModel();
            }
            else
            {
                throw new HttpRequestException($"Error adding {typeof(TModel).Name}: {response.ReasonPhrase}");
            }
        }

        public async Task<TModel> DeleteAsync(TModel entity)
        {
            var response = await _http.DeleteAsync($"api/{typeof(TModel).Name}/DeleteAsync");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TModel>() ?? new TModel();
            }
            else
            {
                throw new HttpRequestException($"Error deleting {typeof(TModel).Name}: {response.ReasonPhrase}");
            }
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var response = await _http.GetAsync($"api/{typeof(TModel).Name}/GetAllAsync");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<TModel>>() ?? new List<TModel>();
            }
            else
            {
                throw new HttpRequestException($"Error getting all {typeof(TModel).Name}: {response.ReasonPhrase}");
            }
        }

        public async Task<TModel> GetAsync(int id)
        {
            var response = await _http.GetAsync($"api/{typeof(TModel).Name}/GetAsync/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TModel>() ?? new TModel();
            }
            else
            {
                throw new HttpRequestException($"Error getting {typeof(TModel).Name} with id {id}: {response.ReasonPhrase}");
            }
        }

        public async Task<TModel> UpdateAsync(TModel entity)
        {
            var response = await _http.PutAsJsonAsync($"api/{typeof(TModel).Name}/UpdateAsync", entity);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TModel>() ?? new TModel();
            }
            else
            {
                throw new HttpRequestException($"Error updating {typeof(TModel).Name}: {response.ReasonPhrase}");
            }
        }
    }
}
