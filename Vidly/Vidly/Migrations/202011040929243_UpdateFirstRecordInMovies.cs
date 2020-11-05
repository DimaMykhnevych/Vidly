namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFirstRecordInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = " +
                "'11/05/2020' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
