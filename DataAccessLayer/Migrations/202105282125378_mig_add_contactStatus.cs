namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contactStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MessageSentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MessageSentDate");
        }
    }
}
