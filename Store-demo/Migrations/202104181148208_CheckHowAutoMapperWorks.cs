namespace Store_demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckHowAutoMapperWorks : DbMigration
    {
        public override void Up()
        {
            RenameColumn("Products", "Name", "Names");
        }
        
        public override void Down()
        {
            RenameColumn("Products", "Names", "Name");
        }
    }
}
