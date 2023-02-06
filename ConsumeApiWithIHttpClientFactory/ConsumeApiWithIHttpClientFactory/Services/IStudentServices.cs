using ConsumeApiWithIHttpClientFactory.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeApiWithIHttpClientFactory.Services
{
    public interface IStudentServices
    {
        Task<AddStudentResponse> AddStudent(AddStudentRequest request);
        Task EditStudent(EditStudentDto request);
        Task RemoveStudent(int studentId);
        Task<GetStudentResponse> GetStudentById(int studentId);
        Task<List<GetStudentResponse>> GetAllStudents();
    }
}
