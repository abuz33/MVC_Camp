namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_testimonials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testimonials", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testimonials", "Approved");
        }
    }
}
