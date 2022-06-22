//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListModels;

namespace ToDoList.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<Detail> SubjectDetails { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }



}

