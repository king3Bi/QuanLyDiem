using System;
using System.Data.Entity;
using System.Linq;
using QLDiem.Entity;

namespace QLDiem.EF
{
    public class ModelQLD : DbContext
    {
        // Your context has been configured to use a 'ModelQLD' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLDiem.EF.ModelQLD' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelQLD' 
        // connection string in the application configuration file.
        public ModelQLD()
            : base("name=ModelQLD")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //----------------------------------

            /*modelBuilder.Entity<SinhVien>()
                .HasOptional<Khoa>(p => p.Khoa)
                .WithMany(p => p.SinhViens)
                .HasForeignKey(p => p.MaK);*/
            //----------------------------------

            modelBuilder.Entity<SinhVien>()
                .HasKey(p => p.MaSV);
            //----------------------------------

            modelBuilder.Entity<MonHoc>()
                .HasKey(p => p.MaMH);
            //---------------------------------

            modelBuilder.Entity<Khoa>()
                .HasKey(p => p.MaK);


            modelBuilder.Entity<SinhVien>()
                .HasRequired(p => p.Khoa)
                .WithMany(p => p.SinhViens)
                .HasForeignKey(p => p.MaK);


            modelBuilder.Entity<KetQua>()
                .HasKey(kq => new { kq.MaSV, kq.MaMH });


            modelBuilder.Entity<KetQua>()
                .HasRequired(p => p.SinhVien)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(p => p.MaSV);

            modelBuilder.Entity<KetQua>()
                .HasRequired(p => p.MonHoc)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(p => p.MaMH);



            /*modelBuilder.Entity<KetQua>()
                .HasOptional<SinhVien>(p => p.SinhVien)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(p => p.MaSV);

            modelBuilder.Entity<KetQua>()
                .HasOptional<Mon>(p => p.Mon)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(p => p.MaMH);*/

        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}