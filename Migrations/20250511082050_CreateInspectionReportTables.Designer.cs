﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ValuationBackend.Data;

#nullable disable

namespace ValuationBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250511082050_CreateInspectionReportTables")]
    partial class CreateInspectionReportTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ValuationBackend.Models.InspectionBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeYears")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BathroomToilet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BathroomToiletDoorsFittings")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingConditions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ceiling")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Conveniences")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Design")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DetailOfBuilding")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Door")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExpectedLifePeriodYears")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FloorFinisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FloorStructure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FoundationStructure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HandRail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InspectionReportId")
                        .HasColumnType("integer");

                    b.Property<string>("NatureOfConstruction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NoOfFloorsAboveGround")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NoOfFloorsAboveGround");

                    b.Property<string>("NoOfFloorsBelowGround")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NoOfFloorsBelowGround");

                    b.Property<string>("OtherDoors")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PantryCupboard")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParkingSpace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoofFinisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoofFrame")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoofMaterial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Services")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Structure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WallFinisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WallStructure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Window")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WindowProtection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InspectionReportId");

                    b.ToTable("InspectionBuildings");
                });

            modelBuilder.Entity("ValuationBackend.Models.InspectionReport", b =>
                {
                    b.Property<int>("InspectionReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InspectionReportId"));

                    b.Property<string>("DetailsOfAssestsInventoryItems")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DetailsOfAssestsInventoryItems");

                    b.Property<string>("DetailsOfBusiness")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DsDivision")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GnDivision")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MasterFileId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MasterFileRefNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherConstructionDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReportId")
                        .HasColumnType("integer");

                    b.Property<string>("Village")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InspectionReportId");

                    b.HasIndex("ReportId");

                    b.ToTable("InspectionReports");
                });

            modelBuilder.Entity("ValuationBackend.Models.LandMiscellaneousMasterFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MasterFileNo")
                        .HasColumnType("integer");

                    b.Property<string>("PlanNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlanType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestingAuthorityReferenceNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LandMiscellaneousMasterFiles");
                });

            modelBuilder.Entity("ValuationBackend.Models.RatingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LocalAuthority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RatingReferenceNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YearOfRevision")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RatingRequests");
                });

            modelBuilder.Entity("ValuationBackend.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReportId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ValuationBackend.Models.InspectionBuilding", b =>
                {
                    b.HasOne("ValuationBackend.Models.InspectionReport", "InspectionReport")
                        .WithMany("Buildings")
                        .HasForeignKey("InspectionReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InspectionReport");
                });

            modelBuilder.Entity("ValuationBackend.Models.InspectionReport", b =>
                {
                    b.HasOne("ValuationBackend.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("ValuationBackend.Models.InspectionReport", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
