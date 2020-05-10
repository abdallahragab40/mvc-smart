namespace MVC.Smart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PhoneNumber");
        }
    }
}
