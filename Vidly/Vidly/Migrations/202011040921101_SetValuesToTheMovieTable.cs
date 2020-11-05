namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetValuesToTheMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, DateAdded, ReleaseDate, " +
                "NumberInStock, GenreId) Values('Hang Over', GETDATE(), 11/05/2020, 2, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
