namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullableTypeToBirthDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthDate", c => c.DateTime(nullable: false));
        }
    }
}
