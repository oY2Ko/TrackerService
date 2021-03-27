using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerService.Models;

namespace SocialService.Models
    {
        public class ApplicationContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
            public DbSet<StudentProfile> StudentProfiles { get; set; }
            public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
        }
    }
