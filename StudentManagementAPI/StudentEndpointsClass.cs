using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
namespace StudentManagementAPI;

public static class StudentEndpointsClass
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", (int page, int pageSize, string searchString,IStudentService studentService) =>
        {
            var students = studentService.GetStudents(page, pageSize, searchString);
            

            var StudentPaging = new StudentPaging();
            StudentPaging.Students = students.Item1;
            StudentPaging.TotalRow = students.Item2;

            return StudentPaging;
        })
        .RequireAuthorization()
        .WithName("GetAllStudents")
        .Produces<List<Student>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{id:int}", async (int ID, IStudentService studentRepository) =>
        {
            return await studentRepository.GetStudentByIdAsync(ID)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("GetStudentById")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Student/{id}", async (int ID, Student student, IStudentService studentService) =>
        {
            try
            {
                await studentService.UpdateStudentAsync(ID, student);
                return Results.NoContent();
            }
            catch 
            {
                return Results.NotFound();
            }
        })
        .RequireAuthorization()
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", async (Student student, IStudentService studentRepository) =>
        {
            student.EnrollmentDate = DateTime.Now;
            await studentRepository.CreateStudentAsync(student);
            return Results.Created($"/Students/{student.ID}", student);
        })
        .RequireAuthorization()
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{id}", async (int ID, IStudentService studentRepository) =>
        {
            return studentRepository.DeleteStudentAsync(ID);
        })
        .RequireAuthorization()
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
