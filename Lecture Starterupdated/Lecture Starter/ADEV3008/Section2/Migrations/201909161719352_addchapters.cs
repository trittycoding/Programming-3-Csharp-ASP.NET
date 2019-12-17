namespace Section2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchapters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Chapters", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Chapters");
        }
    }
}
