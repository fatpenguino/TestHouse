﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestHouse.Infrastructure.Repositories;

namespace TestHouse.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectRespository))]
    partial class ProjectRespositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestHouse.Domain.Models.ProjectAggregate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long?>("RootSuitId");

                    b.HasKey("Id");

                    b.HasIndex("RootSuitId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.Step", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ExpectedResult");

                    b.Property<int>("Order");

                    b.Property<long?>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.StepRun", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<long?>("StepId");

                    b.Property<long?>("TestRunCaseId");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.HasIndex("TestRunCaseId");

                    b.ToTable("TestRunSteps");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.Suit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("Order");

                    b.Property<long?>("ParentSuitId");

                    b.Property<long?>("ProjectAggregateId");

                    b.HasKey("Id");

                    b.HasIndex("ParentSuitId");

                    b.HasIndex("ProjectAggregateId");

                    b.ToTable("Suits");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestCase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ExpectedResult");

                    b.Property<string>("Name");

                    b.Property<long>("Order");

                    b.Property<long?>("SuitId");

                    b.HasKey("Id");

                    b.HasIndex("SuitId");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestRun", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long?>("ProjectAggregateId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectAggregateId");

                    b.ToTable("TestRuns");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestRunCase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<long?>("TestCaseId");

                    b.Property<long?>("TestRunId");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunCases");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.ProjectAggregate", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.Suit", "RootSuit")
                        .WithMany()
                        .HasForeignKey("RootSuitId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.Step", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.TestCase")
                        .WithMany("Steps")
                        .HasForeignKey("TestCaseId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.StepRun", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.Step", "Step")
                        .WithMany()
                        .HasForeignKey("StepId");

                    b.HasOne("TestHouse.Domain.Models.TestRunCase")
                        .WithMany("Steps")
                        .HasForeignKey("TestRunCaseId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.Suit", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.Suit", "ParentSuit")
                        .WithMany()
                        .HasForeignKey("ParentSuitId");

                    b.HasOne("TestHouse.Domain.Models.ProjectAggregate")
                        .WithMany("Suits")
                        .HasForeignKey("ProjectAggregateId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestCase", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.Suit", "Suit")
                        .WithMany("TestCases")
                        .HasForeignKey("SuitId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestRun", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.ProjectAggregate")
                        .WithMany("TestRuns")
                        .HasForeignKey("ProjectAggregateId");
                });

            modelBuilder.Entity("TestHouse.Domain.Models.TestRunCase", b =>
                {
                    b.HasOne("TestHouse.Domain.Models.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TestCaseId");

                    b.HasOne("TestHouse.Domain.Models.TestRun")
                        .WithMany("TestCases")
                        .HasForeignKey("TestRunId");
                });
#pragma warning restore 612, 618
        }
    }
}
