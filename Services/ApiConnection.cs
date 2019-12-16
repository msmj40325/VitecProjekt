using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using VitecProjekt.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace VitecProjekt.Services
{

    public interface IApiConnection
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<HttpStatusCode> DeleteProductAsync(int id);
        Task<Product> EditProductAsync(int id, Product product);

    }
    public class ApiConnection : IApiConnection
    {
        string url = "https://localhost:44309/api/product";
        HttpClient Client = new HttpClient();

        public async Task<List<Product>> GetAllProductsAsync()
        {
            HttpResponseMessage response = await Client.GetAsync(url);

            string content = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(content);

            return products;
        }

        [HttpGet]
        public async Task<Product> GetProduct(int id)
        {
            HttpResponseMessage response = await Client.GetAsync($"{url}/{id}");

            string content = await response.Content.ReadAsStringAsync();
            Product product = JsonConvert.DeserializeObject<Product>(content);

            return product;
        }

        [HttpPost]
        public async Task<Product> CreateProductAsync(Product product)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync($"{url}", stringContent);
            response.EnsureSuccessStatusCode();

            return product;
        }

        [HttpDelete]
        public async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            HttpResponseMessage response = await Client.DeleteAsync($"{url}/{id}");

            return response.StatusCode;
        }

        [HttpPut]
        public async Task<Product> EditProductAsync(int id, Product product)
        {
            //HttpResponseMessage response = await Client.PutAsync($"{url}/{id}", );

            //product = await response.Content.ReadAsAsync<Product>();
            return product;
        }
    }
}
