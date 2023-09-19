using Blazor123.Models;
using Blazor123.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Services.Repos
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbconnection;

        public StudentService() 
        {
            SetUpDb();
        }

        private async void SetUpDb() 
        {
            if (_dbconnection == null) 
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbconnection = new SQLiteAsyncConnection(dbPath);
                await _dbconnection.CreateTableAsync<StudentVm>();
            }
        }

        public async Task<int> AddStudent(StudentVm studentVm)
        {
            return await _dbconnection.InsertAsync(studentVm);
        }

        public async Task<int> DeleteStudent(StudentVm studentVm)
        {
            return await _dbconnection.DeleteAsync(studentVm);
        }

        public async Task<List<StudentVm>> GetAllStudents()
        {
            var students = await _dbconnection.Table<StudentVm>().ToListAsync();
            return students;
        }

        public async Task<int> UpdateStudent(StudentVm studentVm)
        {
            return await _dbconnection.UpdateAsync(studentVm);
        }

        public async Task<StudentVm> GetStudentById(int studentId)
        {
            var student = await _dbconnection.Table<StudentVm>().Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            return student;
        }
    }
}
