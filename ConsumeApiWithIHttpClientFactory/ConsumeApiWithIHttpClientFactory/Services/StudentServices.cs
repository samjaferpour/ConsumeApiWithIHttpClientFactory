using ConsumeApiWithIHttpClientFactory.Dtos;
using ConsumeApiWithIHttpClientFactory.Dtos.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsumeApiWithIHttpClientFactory.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentServices(IHttpClientFactory httpClientFactory) 
        {
            this._httpClientFactory = httpClientFactory;
        }




        //public async Task<GetStudentResponse> AddStudent(AddStudentRequest request)
        //{
        //    var client = _httpClientFactory.CreateClient();


        //    var proxyRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7206/api/Student/Add");
        //    proxyRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            

        //    //proxyRequest.Headers.Add("Accept", "application/json");

        //    var proxyResponse = await client.SendAsync(proxyRequest);
        //    if (!proxyResponse.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Not Found");
        //    }
        //    var proxyResponseString = await proxyResponse.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<GetStudentResponse>(proxyResponseString);
        //    return new GetStudentResponse { Id = result.Id, Name = result.Name, Score = result.Score };

        //}

        public Task EditStudent(EditStudentDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetStudentResponse>> GetAllStudents()
        {
            var client = _httpClientFactory.CreateClient("school");
            var proxyRequest = new HttpRequestMessage(HttpMethod.Get, "api/Student/GetAll");
            proxyRequest.Headers.Add("Accept", "application/json");

            var proxyResponse = await client.SendAsync(proxyRequest);
            if (!proxyResponse.IsSuccessStatusCode)
            {
                throw new Exception("Not Found");
            }
            var proxyResponseString = await proxyResponse.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<GetStudentResponse>>(proxyResponseString);
            return results;
        }

        public Task<GetStudentResponse> GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveStudent(int studentId)
        {
            throw new NotImplementedException();
        }

    }
}
