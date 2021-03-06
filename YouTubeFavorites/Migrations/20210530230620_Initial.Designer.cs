// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouTubeFavorites.Models;

namespace YouTubeFavorites.Migrations
{
    [DbContext(typeof(YouTubeFavoritesContext))]
    [Migration("20210530230620_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("YouTubeFavorites.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("YouTubeFavorites.Models.CategoryYouTubePage", b =>
                {
                    b.Property<int>("CategoryYouTubePageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("YouTubePageId")
                        .HasColumnType("int");

                    b.HasKey("CategoryYouTubePageId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("YouTubePageId");

                    b.ToTable("CategoryYouTubePage");
                });

            modelBuilder.Entity("YouTubeFavorites.Models.YouTubePage", b =>
                {
                    b.Property<int>("YouTubePageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Link")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("YouTubePageId");

                    b.ToTable("YouTubePages");
                });

            modelBuilder.Entity("YouTubeFavorites.Models.CategoryYouTubePage", b =>
                {
                    b.HasOne("YouTubeFavorites.Models.Category", null)
                        .WithMany("JoinEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YouTubeFavorites.Models.YouTubePage", "YouTubePage")
                        .WithMany("JoinEntities")
                        .HasForeignKey("YouTubePageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YouTubePage");
                });

            modelBuilder.Entity("YouTubeFavorites.Models.Category", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("YouTubeFavorites.Models.YouTubePage", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
