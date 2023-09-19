using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor123.Models
{
    public class StudentVm
    {
        [PrimaryKey,AutoIncrement]
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Gender { get; set; }
    }
}
