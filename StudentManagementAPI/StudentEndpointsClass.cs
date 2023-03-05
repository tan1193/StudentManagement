using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
namespace StudentManagementAPI;

public static class StudentEndpointsClass
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", (int page, int pageSize,string searchString, StudentManagementAPIContext db) =>
        {
            var students = db.Student.ToList();
            var totalRow = students.Count;
            students = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstMidName.Contains(searchString) || s.LastName.Contains(searchString) || (s.Phone ?? "").Contains(searchString)).ToList();
            }
            var StudentPaging = new StudentPaging();
            StudentPaging.Students = students;
            StudentPaging.TotalRow = totalRow;

            return StudentPaging;
        })
        .RequireAuthorization()
        .WithName("GetAllStudents")
        .Produces<List<Student>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{id:int}", async (int ID, StudentManagementAPIContext db) =>
        {
            return await db.Student.FindAsync(ID)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("GetStudentById")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Student/{id}", async (int ID, Student student, StudentManagementAPIContext db) =>
        {
            var foundModel = await db.Student.FindAsync(ID);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(student);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .RequireAuthorization()
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", async (Student student, StudentManagementAPIContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.ID}", student);
        })
        .RequireAuthorization()
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{id}", async (int ID, StudentManagementAPIContext db) =>
        {
            if (await db.Student.FindAsync(ID) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
