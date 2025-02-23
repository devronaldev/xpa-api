using Microsoft.EntityFrameworkCore;
using xpa_api.Models.Tables;

namespace xpa_api.Contexts;

public class SeedData
{
    /*
    // Seed Data
    public static void SeedDatabase(AppDbContext context)
    {
        // Criar Escolas
        var schools = new List<School>
        {
            new School { SchoolId = 1, Name = "Escola Alpha" },
            new School { SchoolId = 2, Name = "Escola Beta" },
        };
        context.Schools.AddRange(schools);

        // Criar Usuários
        var users = new List<User>();
        for (var i = 1; i <= 15; i++)
        {
            users.Add(new User { UserId = i, Name = $"Usuário {i}" });
        }
        users.Add(new User{UserId = 0, Name = "Sistema",});
        context.Users.AddRange(users);

        // Conexão de funcionários com escolas
        var employees = new List<Employee>
        {
            new Employee { UserId = 1, SchoolId = 1 },
            new Employee { UserId = 2, SchoolId = 1 },
            new Employee { UserId = 3, SchoolId = 2 },
            new Employee { UserId = 3, SchoolId = 3 }, // Trabalha em mais de uma escola
            new Employee { UserId = 4, SchoolId = 2 },
            new Employee { UserId = 5, SchoolId = 3 }
        };
        modelBuilder.Entity<Employee>().HasData(employees);

        // Criar Turmas
        var classrooms = new List<Class>();
        var classroomId = 1;
        foreach (var school in schools)
        {
            for (var i = 0; i < 2; i++)
            {
                classrooms.Add(new Class { ClassId = classroomId++, SchoolId = school.SchoolId, Name = $"Turma {i + 1} - {school.Name}", Capacity = 5 });
            }
        }
        modelBuilder.Entity<Class>().HasData(classrooms);
    }
    */
}