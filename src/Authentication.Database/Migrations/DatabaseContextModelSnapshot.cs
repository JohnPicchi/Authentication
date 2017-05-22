using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Authentication.Database.Contexts;
using Authentication.Domain.Account.Models;

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
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountProperties", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId")
                        .IsRequired();

                    b.Property<DateTime?>("CurrentLogin");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int?>("FailedLoginAttempts");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<DateTime?>("LockExpiration");

                    b.Property<bool?>("Locked");

                    b.Property<int>("MutliFactorAuthKind");

                    b.Property<Guid>("OpenConnectId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("ResetPassword");

                    b.Property<bool?>("Verified");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountProperties");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.AccountToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId")
                        .IsRequired();

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("ExpirationTime");

                    b.Property<int>("Kind");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountTokens");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId")
                        .IsRequired();

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

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Authentication.PresistenceModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

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

            modelBuilder.Entity("Authentication.PresistenceModels.Claim", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithMany("Claims")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Authentication.PresistenceModels.User", b =>
                {
                    b.HasOne("Authentication.PresistenceModels.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("Authentication.PresistenceModels.User", "AccountId");
                });
        }
    }
}
