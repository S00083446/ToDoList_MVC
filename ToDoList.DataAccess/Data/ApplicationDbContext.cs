﻿using Microsoft.EntityFrameworkCore;
using ToDoListModels;

namespace ToDoList.DataAccess;

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Subjects> Subjects { get; set; }
    }  

 