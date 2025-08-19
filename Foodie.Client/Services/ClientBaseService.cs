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
        private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7001") };

        public async Task<TModel> AddAsync(TModel entity)
        {
            var response = await _http.PostAsJsonAsync($"api/{GetControllerName()}/AddAsync", entity);

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
            var response = await _http.PostAsJsonAsync($"api/{GetControllerName()}/DeleteAsync", entity);

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
            var response = await _http.PostAsync($"api/{GetControllerName()}/GetAllAsync", null);

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
            var response = await _http.PostAsJsonAsync($"api/{GetControllerName()}/GetAsync", id);

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
            var response = await _http.PostAsJsonAsync($"api/{GetControllerName()}/UpdateAsync", entity);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TModel>() ?? new TModel();
            }
            else
            {
                throw new HttpRequestException($"Error updating {typeof(TModel).Name}: {response.ReasonPhrase}");
            }
        }

        private string GetControllerName()
        {
            var typeName = typeof(TModel).Name;
            // Convert USERS -> User, PRODUCT -> Product, etc.
            if (typeName == "USERS")
                return "User";
            if (typeName == "PRODUCT")
                return "Product";
            if (typeName == "ORDER")
                return "Order";
            if (typeName == "ORDER_ITEMS")
                return "OrderItem";
            return typeName;
        }
    }
}
