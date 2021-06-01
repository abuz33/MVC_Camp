﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        RecieverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        SentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
