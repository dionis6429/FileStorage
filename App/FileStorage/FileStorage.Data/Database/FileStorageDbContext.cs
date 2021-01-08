using FileStorage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Data.Database
{
    public class FileStorageDbContext : DbContext
    {
        public DbSet<FileStorageDBEntity> Entities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FileStorage;Integrated Security=true;");
        }
    }
}
