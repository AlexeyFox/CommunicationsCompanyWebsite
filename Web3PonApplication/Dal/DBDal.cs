using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web3PonApplication.Models;
using System.Data.Entity;

namespace Web3PonApplication.Dal
{
    public class DBDal:DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Job>().ToTable("Jobs");
            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<Suggestion>().ToTable("Suggestions");
            /* 
            
            
           
            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<Project>().ToTable("Projects");
             * 
               modelBuilder.Entity<Schedule>().ToTable("Schedules");
               

               */
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        /* 
                   
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }
           public DbSet<Schedule> WorkerSchedule { get; set; }

           */
    }
}