namespace MvcSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeCode = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 255),
                        Category = c.String(maxLength: 12),
                        Dob = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
