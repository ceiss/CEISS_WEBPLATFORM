namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDINGUSERPROC : DbMigration
    {
        public override void Up()
        {
            Sql(@"
CREATE PROC GET_STUDENT @studentid int
AS 
SELECT * 
FROM STUDENTS s 
WHERE s.StudentID =@studentid
 

");
        }
        
        public override void Down()
        {
        }
    }
}
