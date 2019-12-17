namespace Section2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPageCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PageCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PageCount");
        }
    }
}
