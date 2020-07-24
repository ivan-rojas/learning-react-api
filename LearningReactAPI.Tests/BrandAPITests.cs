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
    public class BrandAPITests
    {
        [Fact]
        public async Task Test_GetAll_Brands()
        {
            List<BrandVM> brands;
            string jsonResponse;

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/brand");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                jsonResponse = await response.Content.ReadAsStringAsync();
            }

            brands = JsonConvert.DeserializeObject<List<BrandVM>>(jsonResponse);
            Assert.True(brands.Count > 0);
        }
    }
}
