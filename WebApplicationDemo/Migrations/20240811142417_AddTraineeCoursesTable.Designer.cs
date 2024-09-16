﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationDemo.Data;


#nullable disable

namespace WebApplicationDemo.Migrations
{
    [DbContext(typeof(ITPQ3Context))]
    [Migration("20240811142417_AddTraineeCoursesTable")]
    partial class AddTraineeCoursesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationDemo.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseDegree")
                        .HasColumnType("int");

                    b.Property<int?>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassDegree")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DeptID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<int?>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("DeptID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Trainee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DeptID");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.TraineeCourse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("TraineeDegree")
                        .HasColumnType("int");

                    b.Property<int>("TraineeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TraineeID");

                    b.ToTable("TraineeCourses");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Course", b =>
                {
                    b.HasOne("WebApplicationDemo.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DeptID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Instructor", b =>
                {
                    b.HasOne("WebApplicationDemo.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseID");

                    b.HasOne("WebApplicationDemo.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DeptID");

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Trainee", b =>
                {
                    b.HasOne("WebApplicationDemo.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DeptID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.TraineeCourse", b =>
                {
                    b.HasOne("WebApplicationDemo.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationDemo.Models.Trainee", "Trainee")
                        .WithMany()
                        .HasForeignKey("TraineeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Course", b =>
                {
                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("WebApplicationDemo.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
