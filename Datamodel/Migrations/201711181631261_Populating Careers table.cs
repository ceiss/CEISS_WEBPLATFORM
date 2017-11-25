namespace Datamodel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulatingCareerstable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
  INSERT INTO CAREERS (
       [CareerCode]
      ,[CareerName]  
  )
  VALUES('INS', 'Ingenieria en Sistemas'),('IDS','Ingenieria en Software')
");

        }

        public override void Down()
        {
        }
    }
}
