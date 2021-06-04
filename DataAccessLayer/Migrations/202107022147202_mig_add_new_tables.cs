namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_new_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImageDescription = c.String(maxLength: 1000),
                        ImagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        TestimonialContent = c.String(maxLength: 1000),
                        Name = c.String(maxLength: 20),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Testimonials");
            DropTable("dbo.ProjectImages");
        }
    }
}
