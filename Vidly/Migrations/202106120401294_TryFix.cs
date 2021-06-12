namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            CreateTable(
                "dbo.MembershipTypeDtoes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Membership_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "Membership_Id");
            AddForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypeDtoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypeDtoes");
            DropIndex("dbo.Customers", new[] { "Membership_Id" });
            DropColumn("dbo.Customers", "Membership_Id");
            DropTable("dbo.MembershipTypeDtoes");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
