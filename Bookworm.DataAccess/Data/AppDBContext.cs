﻿using Bookworm.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}