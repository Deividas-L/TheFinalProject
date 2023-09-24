using Blazor123.Application.DTO;
using Blazor123.Domain.Entities;
using Blazor123.Domain.Repositories.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Domain.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private SQLiteAsyncConnection _dbconnection;

        public StudentRepository()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (_dbconnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbconnection = new SQLiteAsyncConnection(dbPath);
                await _dbconnection.CreateTableAsync<Student>();
            }
        }

        public async Task<int> AddStudent(StudentDto studentDto)
        {
            Student student = new Student() 
            {
                StudentId = studentDto.StudentId,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Gender = studentDto.Gender,

            };
            return await _dbconnection.InsertAsync(student);
        }

        public async Task<int> DeleteStudent(StudentDto studentDto)
        {
            Student student = new Student()
            {
                StudentId = studentDto.StudentId,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Gender = studentDto.Gender,

            };
            return await _dbconnection.DeleteAsync(studentDto);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _dbconnection.Table<Student>().ToListAsync();
            return students;
        }

        public async Task<int> UpdateStudent(StudentDto studentDto)
        {
            Student student = new Student()
            {
                StudentId = studentDto.StudentId,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Gender = studentDto.Gender,

            };
            return await _dbconnection.UpdateAsync(student);
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await _dbconnection.Table<Student>().Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            return student;
        }
    }
}
