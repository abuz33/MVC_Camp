namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_contactStatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "ContactStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
        }
    }
}
