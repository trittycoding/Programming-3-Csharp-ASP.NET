namespace BITCollege_TravisTaylor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequiredprogramid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "ProgramId" });
            AlterColumn("dbo.Students", "ProgramId", c => c.Int());
            CreateIndex("dbo.Students", "ProgramId");
            AddForeignKey("dbo.Students", "ProgramId", "dbo.Programs", "ProgramId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "ProgramId" });
            AlterColumn("dbo.Students", "ProgramId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "ProgramId");
            AddForeignKey("dbo.Students", "ProgramId", "dbo.Programs", "ProgramId", cascadeDelete: true);
        }
    }
}
