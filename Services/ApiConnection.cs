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

namespace VitecProjekt.Services
{

    public interface IApiConnection
    {
        Task<List<Product>> GetAllProductsAsync();
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

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(Product product/*string name, double price, string description*/)
        {
            HttpResponseMessage response = await Client.PostAsync($"{url}", product);

            return response.StatusCode;
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
            HttpResponseMessage response = await Client.PutAsync($"{url}/{id}", product);

            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        //public async Task<Product> GetOne(int id)
        //{
        //    string ID = id.ToString();
        //    HttpResponseMessage response = await Client.GetAsync($"https://localhost:44309/api/product/","{0}", ID);
        //    Product product = JsonConvert.DeserializeObject(product);

        //    return Product;
        //}

    }
}
