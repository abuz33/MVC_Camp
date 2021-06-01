namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_draft_message_and_status_to_messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DraftMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        SentDate = c.DateTime(nullable: false),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Messages", "deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "RecieverMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "RecieverMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Messages", "deleted");
            DropColumn("dbo.Messages", "ReceiverMail");
            DropTable("dbo.DraftMessages");
        }
    }
}
