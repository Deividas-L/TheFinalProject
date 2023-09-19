using Blazor123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Services.Interfaces
{
    public interface IStudentService
    {

        Task<List<StudentVm>> GetAllStudents();
        Task<StudentVm> GetStudentById(int studentId);
        Task<int> AddStudent(StudentVm studentVm);
        Task<int> UpdateStudent(StudentVm studentVm);
        Task<int> DeleteStudent(StudentVm studentVm);
    }
}
