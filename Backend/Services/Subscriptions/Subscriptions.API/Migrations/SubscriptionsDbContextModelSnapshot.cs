﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Subscriptions.Infrastructure;

#nullable disable

namespace Subscriptions.API.Migrations
{
    [DbContext(typeof(SubscriptionsDbContext))]
    partial class SubscriptionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SequenceNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SequenceNumber");

                    b.ToTable("_TransactionalEvents", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("AvailableDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AvailableDate");

                    b.HasIndex("CreateDate");

                    b.HasIndex("LastSequenceNumber");

                    b.ToTable("_TransactionalEventsGroup", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Idempotency.IdempotentOperation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("_IdempotentOperation", (string)null);
                });

            modelBuilder.Entity("Subscriptions.Domain.Models.Subscription", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("TargetId")
                        .HasColumnType("text");

                    b.Property<int>("NotificationType")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("SubscriptionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Subscriptions.Domain.Models.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Handle")
                        .HasColumnType("text");

                    b.Property<long>("PrimaryVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.Property<long>("SubscribersCount")
                        .HasColumnType("bigint");

                    b.Property<int>("SubscriptionsCount")
                        .HasColumnType("integer");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("text");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Handle");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventData", b =>
                {
                    b.HasOne("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", null)
                        .WithMany("TransactionalEvents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Infrastructure.TransactionalEvents.TransactionalEvent", "Event", b1 =>
                        {
                            b1.Property<long>("TransactionalEventDataId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Category")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Category");

                            b1.Property<string>("Data")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Data");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Type");

                            b1.HasKey("TransactionalEventDataId");

                            b1.HasIndex("Category");

                            b1.ToTable("_TransactionalEvents");

                            b1.WithOwner()
                                .HasForeignKey("TransactionalEventDataId");
                        });

                    b.Navigation("Event")
                        .IsRequired();
                });

            modelBuilder.Entity("Subscriptions.Domain.Models.Subscription", b =>
                {
                    b.HasOne("Subscriptions.Domain.Models.UserProfile", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Subscriptions.Domain.Models.UserProfile", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Target");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", b =>
                {
                    b.Navigation("TransactionalEvents");
                });
#pragma warning restore 612, 618
        }
    }
}