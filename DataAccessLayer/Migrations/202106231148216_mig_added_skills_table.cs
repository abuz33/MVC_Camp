namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_skills_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 20),
                        SkillPoint = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "WriterId", "dbo.Writers");
            DropIndex("dbo.Skills", new[] { "WriterId" });
            DropTable("dbo.Skills");
        }
    }
}
