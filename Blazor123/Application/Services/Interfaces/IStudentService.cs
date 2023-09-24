using Blazor123.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentById(int studentId);

        Task<List<StudentDto>> GetAllStudents();

        Task<int> UpdateStudent(StudentDto studentDto);
        Task<int> DeleteStudent(StudentDto studentDto);

        Task<int> AddStudent(StudentDto studentDto);
    }
}
