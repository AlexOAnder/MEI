using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MeiFarmWebApi.Contexts;

namespace MeiFarmWebApi.Migrations
{
    [DbContext(typeof(FarmAppContext))]
    partial class FarmAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeiFarmWebApi.Models.MedicamentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<string>("FarmType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.OrganizationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RecipeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<Guid>("AdditionalMedicamentId");

                    b.Property<bool>("AutoUpdatableRecipe");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Expired");

                    b.Property<bool>("IsPaidReceipt");

                    b.Property<Guid>("MedicamentId");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalMedicamentId");

                    b.HasIndex("MedicamentId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<DateTime>("BrithDate");

                    b.Property<string>("FirstName");

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("SecondName");

                    b.Property<string>("Sex");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RecipeModel", b =>
                {
                    b.HasOne("MeiFarmWebApi.Models.MedicamentModel", "AdditionalMedicament")
                        .WithMany()
                        .HasForeignKey("AdditionalMedicamentId");

                    b.HasOne("MeiFarmWebApi.Models.MedicamentModel", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentId");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.UserModel", b =>
                {
                    b.HasOne("MeiFarmWebApi.Models.OrganizationModel", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");
                });
        }
    }
}
