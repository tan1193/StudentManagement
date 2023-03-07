# StudentManagement
This is a web application for managing student records. The frontend of the application is built with ASP.NET MVC and AngularJS, and it can be accessed at https://localhost:7139/. The backend is built with ASP.NET Core minimal API and it can be accessed at https://localhost:7034/.

## Running the Application
1. Clone the repository to your local machine.
2. Navigate to the root folder of the project.
3. Open the solution file (StudentManagement.sln) in Visual Studio.
4. Build the solution.
5. Create the database by running the following commands in the Package Manager Console: Update-Database
6. Start both the frontend and backend projects in Visual Studio.
7. Access the application at https://localhost:7139/

## Features
### Frontend

The frontend of the application can be accessed at https://localhost:7139/. Users can perform the following actions:

- Login page
- Student listing page
- Create a new student
- Student detail Page
- Filter, Paging

### Backend
- Login API
- Get All students API
- Filter student by name, phone number, ID number API
- Create a new student
- Get student detail by ID API
## Swagger

The API documentation for the backend can be accessed at https://localhost:7034/swagger/index.html. This page provides detailed information about the available endpoints, parameters, and responses.

## Technologies Used

- ASP.NET MVC
- AngularJS
- ASP.NET Core minimal API 
- Dependency Injection
- Entity Framework Core
- SQL
