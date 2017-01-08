namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ContractEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ContractEndDate", c => c.DateTime(nullable: false));
        }
    }
}
