namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {   
            CreateTable(
                "dbo.STUDENTS",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
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
                        Career = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.STUDENTS");
        }
    }
}
