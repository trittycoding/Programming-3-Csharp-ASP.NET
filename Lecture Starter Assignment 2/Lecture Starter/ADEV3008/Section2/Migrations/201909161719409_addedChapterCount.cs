namespace Section2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedChapterCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PageCounter", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "ChapterCount", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "PageCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PageCount", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "ChapterCount");
            DropColumn("dbo.Books", "PageCounter");
        }
    }
}
