using System.Collections.Generic;
using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login.Services.Context
{
    public class DataContext:DbContext
    {
        //We have to do the :DbContext so we can inherit from it.

        //We now add all the models that are part of our data in SQL.
        //Think of it like tables.

        public DbSet<credentials> credential {get; set;}

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            //Grab the info from our dataservice that has hardcoded data in it
            
            var fixedData = new List<credentials> {
                new credentials(1, "kevincab", "Chicag0"),
                new credentials(2, "kevin", "Chicag0"),
                new credentials(3, "kevycabbb", "Chicag0"),
                new credentials(4, "whatizit", "Chicag0"),
            };

            //This line helps give the db some seed data.
            builder.Entity<credentials>().HasData(fixedData);
        }
    }
}