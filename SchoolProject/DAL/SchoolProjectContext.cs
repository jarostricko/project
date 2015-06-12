using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SchoolProject.Models;

namespace SchoolProject.DAL
{
    public class SchoolProjectContext:DbContext
    {
        public SchoolProjectContext():base("SchoolProjectContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<ThematicField> ThematicFields { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}