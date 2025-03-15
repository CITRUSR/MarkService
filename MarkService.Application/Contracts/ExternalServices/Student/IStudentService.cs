using MarkService.Application.Contracts.ExternalServices.Student.Dtos;

namespace MarkService.Application.Contracts.ExternalServices.Student;

public interface IStudentService
{
    Task<StudentDto> GetAsync(Guid id);
}
