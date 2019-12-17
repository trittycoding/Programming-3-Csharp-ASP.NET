namespace BITCollege_TravisTaylor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storedprocedures : DbMigration
    {
        public override void Up()
        {
            this.Sql(Properties.Resource1.create_next_number);
        }
        
        public override void Down()
        {
            this.Sql(Properties.Resource1.drop_next_number);
        }
    }
}
