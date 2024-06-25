﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using job_tasks.bd.Connections;

#nullable disable

namespace job_tasks.Migrations
{
    [DbContext(typeof(BdContext))]
    partial class BdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("job_tasks.bd.Entities.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TypeClient")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("job_tasks.bd.Entities.FounderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonDadName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonSecondName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("founders");
                });

            modelBuilder.Entity("job_tasks.bd.Entities.FounderEntity", b =>
                {
                    b.HasOne("job_tasks.bd.Entities.ClientEntity", "Client")
                        .WithMany("Founders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("job_tasks.bd.Entities.ClientEntity", b =>
                {
                    b.Navigation("Founders");
                });
#pragma warning restore 612, 618
        }
    }
}
