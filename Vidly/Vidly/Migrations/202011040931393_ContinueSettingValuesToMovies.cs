namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContinueSettingValuesToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, DateAdded, ReleaseDate, " +
                "NumberInStock, GenreId) Values('Die Hard', GETDATE(), '11/07/2020', 5, 1)");
            Sql("INSERT INTO Movies (Name, DateAdded, ReleaseDate, " +
                "NumberInStock, GenreId) Values('The Terminator', GETDATE(), '11/10/2020', 4, 1)");
            Sql("INSERT INTO Movies (Name, DateAdded, ReleaseDate, " +
                "NumberInStock, GenreId) Values('Toy Story', GETDATE(), '11/08/2020', 6, 3)");
            Sql("INSERT INTO Movies (Name, DateAdded, ReleaseDate, " +
         "NumberInStock, GenreId) Values('Titanic', GETDATE(), '11/12/2020', 8, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
