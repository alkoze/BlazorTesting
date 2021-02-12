using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Repo.StudentRepo
{
    public class StudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Student>>> GetFullStudents(int? id)
        {
            var result = await _context.Students.Select(student => new Student()
            {
                ID = student.ID,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
                Enrollments = student.Enrollments.Select(enrollment => new Enrollment()
                {
                    EnrollmentID = enrollment.EnrollmentID,
                    Grade = enrollment.Grade,
                    Course = new Course
                    {
                        CourseID = enrollment.CourseID,
                        Title = enrollment.Course.Title,
                        Credits = enrollment.Course.Credits
                    }
                }).ToList()
            }).ToListAsync();
            if (id != null)
            {
                result = result.FindAll(student => student.ID == id);
            }
            return result;
        }
    }
}
