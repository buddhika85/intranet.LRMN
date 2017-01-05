namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ContractEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserLocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine3", c => c.String());
            AddColumn("dbo.AspNetUsers", "CountyOrRegion", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "VolunteerInterests", c => c.String());
            AddColumn("dbo.AspNetUsers", "ContactTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ContactTypeId");
            AddForeignKey("dbo.AspNetUsers", "ContactTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.AspNetUsers", new[] { "ContactTypeId" });
            DropColumn("dbo.AspNetUsers", "ContactTypeId");
            DropColumn("dbo.AspNetUsers", "VolunteerInterests");
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "CountyOrRegion");
            DropColumn("dbo.AspNetUsers", "AddressLine3");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            DropColumn("dbo.AspNetUsers", "UserLocked");
            DropColumn("dbo.AspNetUsers", "UserActive");
            DropColumn("dbo.AspNetUsers", "ContractEndDate");
            DropColumn("dbo.AspNetUsers", "JoinDate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
