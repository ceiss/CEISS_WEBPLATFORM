namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingpreviewfieldtoarticles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Preview", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String(maxLength: 140));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String());
            DropColumn("dbo.Articles", "Preview");
        }
    }
}
