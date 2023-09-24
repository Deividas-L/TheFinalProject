using Blazor123.Application.DTO;
using Blazor123.Application.Services.Interfaces;
using Blazor123.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Application.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> AddStudent(StudentDto studentDto)
        {
            return await _studentRepository.AddStudent(studentDto);
        }

        public async Task<int> DeleteStudent(StudentDto studentDto)
        {
            return await _studentRepository.DeleteStudent(studentDto);
        }
        public async Task<int> UpdateStudent(StudentDto studentDto)
        {
            return await _studentRepository.UpdateStudent(studentDto);
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {

            var students = await _studentRepository.GetAllStudents();
            var studentDtoList = new List<StudentDto>();
            foreach (var student in students) 
            {
                StudentDto dto = new StudentDto()
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Gender = student.Gender,

                };
                studentDtoList.Add(dto);
            }
            return studentDtoList;
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            StudentDto dto = new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Gender = student.Gender,

            };
            return dto;
        }


    }
}
