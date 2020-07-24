using FluentAssertions;
using LearningReactAPI.Data.Models;
using LearningReactAPI.Domain.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearningReactAPI.Tests
{
    public class ProductAPITests
    {
        [Fact]
        public async Task Test_GetAll_Products()
        {
            List<ProductVM> products;
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();
            }

            products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
            Assert.True(products.Count > 0);
        }

        [Fact]
        public async Task Test_Add_Product()
        {
            // TODO: The add product method should return at least the id of the product inserted in the database.
            // TODO: If the test fails it has to remove the object anyway.

            Product product = new Product
            {
                Name = "UnitTestProduct000001",
                Cost = 20.50f,
                Price = 21.50f,
                BrandId = 1
            };
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                string jsonRequestBody = JsonConvert.SerializeObject(product);
                var response = await client.PostAsync("/api/product", new StringContent(jsonRequestBody, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
                var productFound = products.Find(x => x.Name == product.Name);
                Assert.NotNull(productFound);
                await client.DeleteAsync("/api/product/" + productFound.Id);
            }

        }

        [Fact]
        public async Task Test_Get_Product()
        {
            int productId;
            ProductVM productToReview;
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
                var random = new Random();
                int index = random.Next(products.Count);
                productId = products[index].Id;

                response = await client.GetAsync("/api/product/" + productId);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();
            }

            productToReview = JsonConvert.DeserializeObject<ProductVM>(jsonResponse);
            Assert.NotNull(productToReview);
        }

        [Fact]
        public async Task Test_Delete_Product()
        {
            Product product = new Product
            {
                Name = "UnitTestProduct000001",
                Cost = 20.50f,
                Price = 21.50f,
                BrandId = 1
            };
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                string jsonRequestBody = JsonConvert.SerializeObject(product);
                var response = await client.PostAsync("/api/product", new StringContent(jsonRequestBody, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
                var productFound = products.Find(x => x.Name == product.Name);

                response = await client.DeleteAsync("/api/product/"+productFound.Id);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
                var deletedProduct = products.Find(x => x.Id == productFound.Id);
                Assert.Null(deletedProduct);
            }
        }

        [Fact]
        public async Task Test_Update_Product()
        {
            Product product = new Product
            {
                Name = "UnitTestProduct000001",
                Cost = 20.50f,
                Price = 21.50f,
                BrandId = 1
            };
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                string jsonRequestBody = JsonConvert.SerializeObject(product);
                var response = await client.PostAsync("/api/product", new StringContent(jsonRequestBody, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ProductVM>>(jsonResponse);
                var productFound = products.Find(x => x.Name == product.Name);

                product.Name = "PutIntegrationTest0000001";
                product.Price = 10;
                product.Cost = 5;
                product.BrandId = 3;
                jsonRequestBody = JsonConvert.SerializeObject(product);

                response = await client.PutAsync("/api/product/" + productFound.Id, new StringContent(jsonRequestBody, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                response = await client.GetAsync("/api/product/" + productFound.Id);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();

                product.Id = productFound.Id;
                var updatedProduct = JsonConvert.DeserializeObject<ProductVM>(jsonResponse);
          
                Assert.True(CompareProducts(updatedProduct, product));
                await client.DeleteAsync("/api/product/" + updatedProduct.Id);
            }
        }

        private bool CompareProducts(ProductVM prodVM, Product prod)
        {
            return  prodVM.Id == prod.Id &&
                    prodVM.Name == prod.Name &&
                    prodVM.Price == prod.Price &&
                    prodVM.Cost == prod.Cost &&
                    prodVM.Brand.Id == prod.BrandId;
        }
    }
}
