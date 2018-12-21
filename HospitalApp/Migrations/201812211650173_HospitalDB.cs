namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        TimeStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Speciality = c.String(),
                        Password = c.String(),
                        UserStatus = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        UserStatus = c.String(),
                        SurgeryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        AcceptTimeId = c.Int(nullable: false),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcceptTimes", t => t.AcceptTimeId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.AcceptTimeId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        IsFull = c.Boolean(nullable: false),
                        WardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorAcceptTimes",
                c => new
                    {
                        Doctor_Id = c.Int(nullable: false),
                        AcceptTime_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id, t.AcceptTime_Id })
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.AcceptTimes", t => t.AcceptTime_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.AcceptTime_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Queues", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Queues", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Queues", "AcceptTimeId", "dbo.AcceptTimes");
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DoctorAcceptTimes", "AcceptTime_Id", "dbo.AcceptTimes");
            DropForeignKey("dbo.DoctorAcceptTimes", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.DoctorAcceptTimes", new[] { "AcceptTime_Id" });
            DropIndex("dbo.DoctorAcceptTimes", new[] { "Doctor_Id" });
            DropIndex("dbo.Rooms", new[] { "WardId" });
            DropIndex("dbo.Queues", new[] { "AcceptTimeId" });
            DropIndex("dbo.Queues", new[] { "PatientId" });
            DropIndex("dbo.Queues", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropTable("dbo.DoctorAcceptTimes");
            DropTable("dbo.Wards");
            DropTable("dbo.Rooms");
            DropTable("dbo.Queues");
            DropTable("dbo.Patients");
            DropTable("dbo.Departments");
            DropTable("dbo.Doctors");
            DropTable("dbo.AcceptTimes");
        }
    }
}
