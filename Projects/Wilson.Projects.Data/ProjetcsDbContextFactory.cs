﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace Wilson.Projects.Data
{
    public class ProjectsDbContextFactory : IDesignTimeDbContextFactory<ProjectsDbContext>
    {
        public ProjectsDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<ProjectsDbContext>();
            builder.UseSqlServer("Server=.;Database=Wilson;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ProjectsDbContext(builder.Options);
        }

        public ProjectsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProjectsDbContext>();
            builder.UseSqlServer("Server=.;Database=Wilson;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ProjectsDbContext(builder.Options);
        }
    }
}