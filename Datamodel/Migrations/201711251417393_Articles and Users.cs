namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticlesandUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        HTMLContent = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        PrimaryImage = c.String(),
                        Author_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.USERS", t => t.Author_UserID)
                .Index(t => t.Author_UserID);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        SecondName = c.String(maxLength: 30),
                        FirstLastName = c.String(nullable: false, maxLength: 30),
                        SecondLastName = c.String(maxLength: 30),
                        Email = c.String(),
                        Cellphone = c.String(),
                        Phone = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Password = c.String(),
                        Salt = c.Binary(),
                        Career_CareerId = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.CAREERS", t => t.Career_CareerId)
                .Index(t => t.Career_CareerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Author_UserID", "dbo.USERS");
            DropForeignKey("dbo.USERS", "Career_CareerId", "dbo.CAREERS");
            DropIndex("dbo.USERS", new[] { "Career_CareerId" });
            DropIndex("dbo.Articles", new[] { "Author_UserID" });
            DropTable("dbo.USERS");
            DropTable("dbo.Articles");
        }
    }
}
