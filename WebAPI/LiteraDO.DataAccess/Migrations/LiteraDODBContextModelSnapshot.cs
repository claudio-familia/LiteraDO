﻿// <auto-generated />
using System;
using LiteraDO.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiteraDO.DataAccess.Migrations
{
    [DbContext(typeof(LiteraDODBContext))]
    partial class LiteraDODBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LiteraDO.Domain.Readers.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("HasAdultContent")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("LiteraryGenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Reads")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TagetAudience")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LiteraryGenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.BookUserState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ChapterWhereTheyLeft")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastReadingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RatingComment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUserStates");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.LiteraryGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LiteraryGenres");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.UserFavoriteGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("LiteraryGenreId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LiteraryGenreId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavoriteGenres");
                });

            modelBuilder.Entity("LiteraDO.Domain.Users.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LiteraDO.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TargetPreference")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CopyrightType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("HasAdultContent")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("LiteraryGenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Reads")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TagetAudience")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LiteraryGenreId");

                    b.HasIndex("UserId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryChapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("StoryChapters");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("StoryCharacters");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryReports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Evidence")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Status")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("StoryReports");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoryChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StoryReviews");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.Author", b =>
                {
                    b.HasOne("LiteraDO.Domain.Users.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.Book", b =>
                {
                    b.HasOne("LiteraDO.Domain.Readers.LiteraryGenre", "LiteraryGenre")
                        .WithMany()
                        .HasForeignKey("LiteraryGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryGenre");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.BookAuthor", b =>
                {
                    b.HasOne("LiteraDO.Domain.Readers.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteraDO.Domain.Readers.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.BookUserState", b =>
                {
                    b.HasOne("LiteraDO.Domain.Readers.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteraDO.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.UserFavoriteGenre", b =>
                {
                    b.HasOne("LiteraDO.Domain.Readers.LiteraryGenre", "Genre")
                        .WithMany()
                        .HasForeignKey("LiteraryGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteraDO.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LiteraDO.Domain.Users.User", b =>
                {
                    b.HasOne("LiteraDO.Domain.Users.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.Story", b =>
                {
                    b.HasOne("LiteraDO.Domain.Readers.LiteraryGenre", "LiteraryGenre")
                        .WithMany()
                        .HasForeignKey("LiteraryGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteraDO.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryGenre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryChapter", b =>
                {
                    b.HasOne("LiteraDO.Domain.Writers.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryCharacter", b =>
                {
                    b.HasOne("LiteraDO.Domain.Writers.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("LiteraDO.Domain.Writers.StoryReports", b =>
                {
                    b.HasOne("LiteraDO.Domain.Writers.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("LiteraDO.Domain.Readers.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}
