namespace Store_demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReverseChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn("Products", "Names", "Name");
        }

        public override void Down()
        {
            RenameColumn("Products", "Name", "Names");
        }
    }
}
