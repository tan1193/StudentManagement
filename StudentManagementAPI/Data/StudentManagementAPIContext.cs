using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Data
{
    public class StudentManagementAPIContext : DbContext
    {
        public StudentManagementAPIContext (DbContextOptions<StudentManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StudentManagementAPI.Models.Student> Student { get; set; } = default!;
    }
}
