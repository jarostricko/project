﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolProject.Controllers;
using SchoolProject.Models;
using SchoolProject.ViewModels;

namespace SchoolProject.DAL
{
    public class SchoolProjectContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolProjectContext()
            : base("SchoolProjectContext", throwIfV1Schema: false)
        {
            
        }
        public static SchoolProjectContext Create()
        {
            return new SchoolProjectContext();
        }

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<ThematicField> ThematicFields { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<EditUserViewModel> EditUserViewModels { get; set; }
        public DbSet<StudentsTest> StudentsTests { get; set; }
        public DbSet<TestViewModel> TestViewModels { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        

    }
}