﻿using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class ContextApi : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =(LocalDB)\\MSSQLLocalDB;database=CoreBlogApiDb;integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
