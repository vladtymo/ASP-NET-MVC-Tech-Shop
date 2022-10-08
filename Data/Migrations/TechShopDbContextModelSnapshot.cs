﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(TechShopDbContext))]
    partial class TechShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OperationSystemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OperationSystemId");

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Display = "13.3″ Full HD",
                            ImagePath = "https://img.moyo.ua/img/gallery/4867/43/1104939_middle.jpg?1617223785",
                            Model = "Dell Latitude 5320",
                            OperationSystemId = 1,
                            Price = 699m,
                            Processor = "11th Gen Intel® Core i5"
                        },
                        new
                        {
                            Id = 2,
                            Display = "11.6″ HD LED Display",
                            ImagePath = "https://i5.walmartimages.com/asr/8d794c17-41b0-42b2-9e11-4c60bfd81af0_1.54a5a04f52a9a6f929e635df6d8c31e6.jpeg",
                            Model = "Samsung Chromebook 4 310XBA-KA1",
                            OperationSystemId = 1,
                            Price = 199m,
                            Processor = "Intel® Dual-Core"
                        },
                        new
                        {
                            Id = 3,
                            Display = "13.3″ Full HD IPS Touch Screen",
                            ImagePath = "https://www.notebookcheck-ru.com/uploads/tx_nbc2/LenovoIdeaPadFlex5-14IIL05__1__06.JPG",
                            Model = "Lenovo IdeaPad Flex 5",
                            OperationSystemId = 3,
                            Price = 419m,
                            Processor = "Intel® Core i3"
                        },
                        new
                        {
                            Id = 4,
                            Display = "14” 4K Anti-glare",
                            ImagePath = "https://hotline.ua/img/tx/132/13238035.jpg",
                            Model = "Dell Latitude E7420",
                            OperationSystemId = 4,
                            Price = 899m,
                            Processor = "11th Gen Intel Core i7"
                        });
                });

            modelBuilder.Entity("Data.Models.OperationSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationSystems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Windows"
                        },
                        new
                        {
                            Id = 2,
                            Name = "macOS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Linux"
                        },
                        new
                        {
                            Id = 4,
                            Name = "MS DOS"
                        });
                });

            modelBuilder.Entity("Data.Models.Laptop", b =>
                {
                    b.HasOne("Data.Models.OperationSystem", "OperationSystem")
                        .WithMany("Laptops")
                        .HasForeignKey("OperationSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationSystem");
                });

            modelBuilder.Entity("Data.Models.OperationSystem", b =>
                {
                    b.Navigation("Laptops");
                });
#pragma warning restore 612, 618
        }
    }
}
