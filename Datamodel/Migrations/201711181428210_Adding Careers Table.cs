namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddingCareersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CAREERS",
                c => new
                {
                    CareerId = c.Int(nullable: false, identity: true),
                    CareerCode = c.String(maxLength: 6),
                    CareerName = c.String(maxLength: 30),
                })
                .PrimaryKey(t => t.CareerId);

            AddColumn("dbo.STUDENTS", "CareerID", c => c.Int(nullable: false));
            CreateIndex("dbo.STUDENTS", "CareerID");
            AddForeignKey("dbo.STUDENTS", "CareerID", "dbo.CAREERS", "CareerId", cascadeDelete: true);
            DropColumn("dbo.STUDENTS", "Career");
        }

        public override void Down()
        {
            AddColumn("dbo.STUDENTS", "Career", c => c.Int(nullable: false));
            DropForeignKey("dbo.STUDENTS", "CareerID", "dbo.CAREERS");
            DropIndex("dbo.STUDENTS", new[] { "CareerID" });
            DropColumn("dbo.STUDENTS", "CareerID");
            DropTable("dbo.CAREERS");
        }
    }
}
