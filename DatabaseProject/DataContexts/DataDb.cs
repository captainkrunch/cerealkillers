using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseProject.DataContexts
{
    public class DataDb : DbContext
    {
        public DataDb() : base("name=DefaultConnection")
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Person_Class> P_Classes { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Person_Team> P_Teams { get; set; }

        public DbSet<Person_Event> P_Events { get; set; }
    }

}