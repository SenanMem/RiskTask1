// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domains.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domains.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.EntityFrameworkCore.AutoHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Changed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<string>("RowId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("AutoHistory");
                });

            modelBuilder.Entity("Domains.TeamLeader", b =>
                {
                    b.HasBaseType("Domains.User");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TeamLeaders");
                });

            modelBuilder.Entity("Domains.Worker", b =>
                {
                    b.HasBaseType("Domains.User");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<int>("TeamLeaderId")
                        .HasColumnType("int");

                    b.HasIndex("TeamLeaderId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Domains.Comment", b =>
                {
                    b.HasOne("Domains.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Domains.Notification", b =>
                {
                    b.HasOne("Domains.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Domains.TeamLeader", b =>
                {
                    b.HasOne("Domains.User", null)
                        .WithOne()
                        .HasForeignKey("Domains.TeamLeader", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domains.Worker", b =>
                {
                    b.HasOne("Domains.User", null)
                        .WithOne()
                        .HasForeignKey("Domains.Worker", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domains.TeamLeader", "TeamLeader")
                        .WithMany("Workers")
                        .HasForeignKey("TeamLeaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TeamLeader");
                });

            modelBuilder.Entity("Domains.TeamLeader", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
