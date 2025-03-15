using Mapster;
using MarkService.Application.Contracts.ExternalServices.Student;
using MarkService.Application.Contracts.ExternalServices.Student.Dtos;

namespace MarkService.Infrastructure.ExternalServices.UserService.Student;

public class StudentService(UserServiceClient.StudentService.StudentServiceClient client)
    : IStudentService
{
    private readonly UserServiceClient.StudentService.StudentServiceClient _client = client;

    public async Task<StudentDto> GetAsync(Guid id)
    {
        var student = await _client.GetStudentByIdAsync(
            new UserServiceClient.GetStudentByIdRequest { Id = id.ToString() }
        );

        return student.Adapt<StudentDto>();
    }
}
