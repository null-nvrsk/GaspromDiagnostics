// <auto-generated />
using GaspromDiagnostics.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GaspromDiagnostics.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221115132004_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("GaspromDiagnostics.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Angle")
                        .HasColumnType("REAL");

                    b.Property<float>("Distance")
                        .HasColumnType("REAL");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsDefect")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Width")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Objects");
                });
#pragma warning restore 612, 618
        }
    }
}
