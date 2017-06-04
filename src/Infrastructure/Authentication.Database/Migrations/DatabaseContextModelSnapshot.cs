using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Authentication.Database.Contexts;
using Authentication.Account.Models;

namespace Authentication.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Authentication.PresistenceModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<bool?>("IsVerified");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Issuer")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountClaims");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountLock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<int>("Kind");

                    b.Property<string>("Message")
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountLocks");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountProperties", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime?>("CurrentLoginDateTime");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int?>("FailedLoginAttempts");

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<int>("MutliFactorAuthKind");

                    b.Property<Guid?>("OpenConnectId");

                    b.Property<bool?>("PasswordResetRequired");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountProperties");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<int>("Kind");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountTokens");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountClaim", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithMany("Claims")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountLock", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithMany("Locks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountProperties", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithOne("Properties")
                        .HasForeignKey("Authentication.PresistenceModels.AccountProperties", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountToken", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithMany("Tokens")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.PresistenceModels.User", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("Authentication.PresistenceModels.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
