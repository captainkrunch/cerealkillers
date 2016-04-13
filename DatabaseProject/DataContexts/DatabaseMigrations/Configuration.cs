namespace DatabaseProject.DataContexts.DatabaseMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseProject.DataContexts.DataDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\DatabaseMigrations";
        }

        protected override void Seed(DatabaseProject.DataContexts.DataDb context)
        {          

        }
    }
}
