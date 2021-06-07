namespace QLDiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KetQuas",
                c => new
                    {
                        MaSV = c.Int(nullable: false),
                        MaMH = c.Int(nullable: false),
                        Diem = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaSV, t.MaMH })
                .ForeignKey("dbo.MonHocs", t => t.MaMH, cascadeDelete: true)
                .ForeignKey("dbo.SinhViens", t => t.MaSV, cascadeDelete: true)
                .Index(t => t.MaSV)
                .Index(t => t.MaMH);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMH = c.Int(nullable: false, identity: true),
                        TenMH = c.String(),
                        SoTinChi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMH);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSV = c.Int(nullable: false, identity: true),
                        HoVaTen = c.String(),
                        Phai = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        MaK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSV)
                .ForeignKey("dbo.Khoas", t => t.MaK, cascadeDelete: true)
                .Index(t => t.MaK);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        MaK = c.Int(nullable: false, identity: true),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.MaK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KetQuas", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.SinhViens", "MaK", "dbo.Khoas");
            DropForeignKey("dbo.KetQuas", "MaMH", "dbo.MonHocs");
            DropIndex("dbo.SinhViens", new[] { "MaK" });
            DropIndex("dbo.KetQuas", new[] { "MaMH" });
            DropIndex("dbo.KetQuas", new[] { "MaSV" });
            DropTable("dbo.Khoas");
            DropTable("dbo.SinhViens");
            DropTable("dbo.MonHocs");
            DropTable("dbo.KetQuas");
        }
    }
}
