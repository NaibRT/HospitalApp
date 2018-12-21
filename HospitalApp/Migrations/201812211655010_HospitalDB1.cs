namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DoctorAcceptTimes", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.DoctorAcceptTimes", "AcceptTime_Id", "dbo.AcceptTimes");
            DropIndex("dbo.DoctorAcceptTimes", new[] { "Doctor_Id" });
            DropIndex("dbo.DoctorAcceptTimes", new[] { "AcceptTime_Id" });
            AddColumn("dbo.Doctors", "AcceptTime_Id", c => c.Int());
            CreateIndex("dbo.Doctors", "AcceptTime_Id");
            AddForeignKey("dbo.Doctors", "AcceptTime_Id", "dbo.AcceptTimes", "Id");
            DropTable("dbo.DoctorAcceptTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoctorAcceptTimes",
                c => new
                    {
                        Doctor_Id = c.Int(nullable: false),
                        AcceptTime_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id, t.AcceptTime_Id });
            
            DropForeignKey("dbo.Doctors", "AcceptTime_Id", "dbo.AcceptTimes");
            DropIndex("dbo.Doctors", new[] { "AcceptTime_Id" });
            DropColumn("dbo.Doctors", "AcceptTime_Id");
            CreateIndex("dbo.DoctorAcceptTimes", "AcceptTime_Id");
            CreateIndex("dbo.DoctorAcceptTimes", "Doctor_Id");
            AddForeignKey("dbo.DoctorAcceptTimes", "AcceptTime_Id", "dbo.AcceptTimes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DoctorAcceptTimes", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
