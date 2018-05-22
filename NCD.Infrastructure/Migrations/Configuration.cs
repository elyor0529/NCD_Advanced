namespace NCD.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NCD.Infrastructure.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NCD.Infrastructure.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //test sql script
            var sql = @"insert into Person values ('John White', 'John', '1965-6-10', 'Male', '170', '90', '1', 'USA');
insert into Person values ('Natalie Black', 'Black', '1966-11-10', 'Female', '165', '54', '1', 'USA');
insert into Person values ('Simon Yellow', 'Y', '1978-6-1', 'Male', '180', '80', '1', 'UK');
insert into Person values ('Jessica Red', 'Jessy', '1980-2-4', 'Female', '160', '70', '1', 'USA');
insert into Person values ('Monika Brown', 'Bro', '1979-2-5', 'Female', '167', '78', '1', 'UK');
insert into Person values ('Joshua Aquamarine', 'Josh', '1965-3-8', 'Male', '185', '92', '1', 'USA');
insert into Person values ('Jim Blue', 'Jimmy', '1967-4-8', 'Male', '174', '65', '1', 'UK');
insert into Person values ('Angela Green', 'Angie', '1975-2-9', 'Female', '167', '77', '1', 'USA');
insert into Person values ('Dorian Gray', 'Doctor', '1945-4-11', 'Male', '179', '88', '1', 'UK');
insert into Person values ('Marina Violet', 'Mary V', '1965-1-3', 'Female', '167', '70', '1', 'USA');
insert into Person values ('Modesty Gold', 'Mood', '1978-5-5', 'Female', '165', '55', '1', 'UK');
insert into Person values ('Markos Navy', 'Mc', '1964-7-2', 'Male', '178', '90', '1', 'USA');
insert into Person values ('Alanah White', 'Al', '1966-7-10', 'Female', '168', '60', '1', 'USA');";

            context.Database.ExecuteSqlCommand(sql);
        }
    }
}
