﻿// <auto-generated />
using System;
using DojoCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DojoCenter.Migrations
{
    [DbContext(typeof(CenterContext))]
    partial class CenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DojoCenter.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ShindigId");

                    b.Property<int>("UserId");

                    b.HasKey("ParticipantId");

                    b.HasIndex("ShindigId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("DojoCenter.Models.Shindig", b =>
                {
                    b.Property<int>("ShindigId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<string>("DurationSegment")
                        .IsRequired();

                    b.Property<int>("PlannerId");

                    b.Property<string>("ShindigDate")
                        .IsRequired();

                    b.Property<string>("ShindigTime")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ShindigId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Shindigs");
                });

            modelBuilder.Entity("DojoCenter.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DojoCenter.Models.Participant", b =>
                {
                    b.HasOne("DojoCenter.Models.Shindig", "Shindig")
                        .WithMany("Shindigname")
                        .HasForeignKey("ShindigId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DojoCenter.Models.User", "User")
                        .WithMany("Planner")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DojoCenter.Models.Shindig", b =>
                {
                    b.HasOne("DojoCenter.Models.User", "Planner")
                        .WithMany()
                        .HasForeignKey("PlannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
