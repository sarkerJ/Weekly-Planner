﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weekly_PlannerDataLayer;

namespace Weekly_PlannerDataLayer.Migrations
{
    [DbContext(typeof(WeeklyPlannerDBContext))]
    [Migration("20201104205002_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weekly_PlannerDataLayer.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekDayId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("WeekDayId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Weekly_PlannerDataLayer.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotesColourCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekDayId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("NotesColourCategoryId");

                    b.HasIndex("WeekDayId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Weekly_PlannerDataLayer.NotesColourCategory", b =>
                {
                    b.Property<int>("NotesColourCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotesColourCategoryId");

                    b.ToTable("NotesColourCategories");
                });

            modelBuilder.Entity("Weekly_PlannerDataLayer.WeekDay", b =>
                {
                    b.Property<int>("WeekDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeekDayId");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("Weekly_PlannerDataLayer.Activity", b =>
                {
                    b.HasOne("Weekly_PlannerDataLayer.WeekDay", "WeekDays")
                        .WithMany()
                        .HasForeignKey("WeekDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Weekly_PlannerDataLayer.Note", b =>
                {
                    b.HasOne("Weekly_PlannerDataLayer.NotesColourCategory", "NotesColourCategorys")
                        .WithMany()
                        .HasForeignKey("NotesColourCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weekly_PlannerDataLayer.WeekDay", "WeekDays")
                        .WithMany()
                        .HasForeignKey("WeekDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
