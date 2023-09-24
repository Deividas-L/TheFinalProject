using Blazor123.Application.DTO;
using Blazor123.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Domain.Repositories.Interfaces
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<int> AddStudent(StudentDto studentDto);
        Task<int> UpdateStudent(StudentDto studentDto);
        Task<int> DeleteStudent(StudentDto studentDto);
    }
}
