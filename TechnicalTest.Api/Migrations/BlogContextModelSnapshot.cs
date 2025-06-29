﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalTest.Infrastructure;

#nullable disable

namespace TechnicalTest.Api.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("TechnicalTest.Core.Authors.ReadModels.AuthorReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuthorReadModels");
                });

            modelBuilder.Entity("TechnicalTest.Core.DomainEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EventStreamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventStreamId");

                    b.ToTable("DomainEvent");

                    b.HasDiscriminator().HasValue("DomainEvent");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TechnicalTest.Core.Posts.ReadModels.PostReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PostReadModels");
                });

            modelBuilder.Entity("TechnicalTest.Infrastructure.Repositories.EventStore.EventStream", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AggregateType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EventStreams");
                });

            modelBuilder.Entity("TechnicalTest.Core.Authors.Events.AuthorCreatedEvent", b =>
                {
                    b.HasBaseType("TechnicalTest.Core.DomainEvent");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("AuthorCreatedEvent");
                });

            modelBuilder.Entity("TechnicalTest.Core.Posts.Events.PostCreatedEvent", b =>
                {
                    b.HasBaseType("TechnicalTest.Core.DomainEvent");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("DomainEvent", t =>
                        {
                            t.Property("AuthorId")
                                .HasColumnName("PostCreatedEvent_AuthorId");
                        });

                    b.HasDiscriminator().HasValue("PostCreatedEvent");
                });

            modelBuilder.Entity("TechnicalTest.Core.DomainEvent", b =>
                {
                    b.HasOne("TechnicalTest.Infrastructure.Repositories.EventStore.EventStream", null)
                        .WithMany("Events")
                        .HasForeignKey("EventStreamId");
                });

            modelBuilder.Entity("TechnicalTest.Infrastructure.Repositories.EventStore.EventStream", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
