﻿using BropertyBrosApi.Models;
using BropertyBrosApi2._0.Constants;
using BropertyBrosApi2._0.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BropertyBrosApi.Data
{
    //Author: Calvin, Daniel, Emil
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RealtorFirm> RealtorFirms { get; set; }
        public DbSet<Realtor> Realtors { get; set; }

        //Author: Calvin
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Realtor>()
                .HasOne(r => r.User)
                .WithOne(u => u.Realtor)
                .HasForeignKey<Realtor>(r => r.UserId)
                .IsRequired();

            //Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "5fb43755-efa6-428e-8f70-024d3294c7b6",
                    Name = IdentityRoles.Admin,
                    NormalizedName = IdentityRoles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "bc472e9f-773c-4e71-a524-f37911680d76",
                    Name = IdentityRoles.User,
                    NormalizedName = IdentityRoles.User.ToUpper()
                }
            );

            //Users
            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "da73186d-928a-4e7b-af8e-d69ebe4ea2c9",
                    Email = "admin@broperty.com",
                    NormalizedEmail = "ADMIN@BROPERTY.COM",
                    UserName = "admin@broperty.com",
                    NormalizedUserName = "ADMIN@BROPERTY.COM",
                    FirstName = "Chad",
                    LastName = "Broperty",
                    PasswordHash = "AQAAAAIAAYagAAAAELeUE3g9g6OTSqBTc9ton2GMurerIw4dCslq57D14LC8knhko3oWy/20+BxhAdO/UA==",
                    SecurityStamp = "abe6397f-14eb-4a7a-979e-18f7cbffb787",
                    ConcurrencyStamp = "d3c5ba60-0a1a-4c99-8646-41e8d3c350a9",
                    EmailConfirmed = true,
                },
                new ApiUser
                {
                    Id = "e537ba2e-a85f-4c2e-bd43-2940963f7856",
                    Email = "user1@broperty.com",
                    NormalizedEmail = "USER1@BROPERTY.COM",
                    UserName = "user1@broperty.com",
                    NormalizedUserName = "USER1@BROPERTY.COM",
                    FirstName = "Emil",
                    LastName = "Svensson",
                    PasswordHash = "AQAAAAIAAYagAAAAEBX1pIrj+1YNKaog05C+oOx9U5r/rvnyN4SvLNfSqUr1zL54+iXnda0ujBN9v6wdeQ==",
                    SecurityStamp = "02c42ac2-c5c5-4da5-8771-6d487c8f947e",
                    ConcurrencyStamp = "21dd539d-4565-4ddd-8c10-e7fb21022b0f",
                    EmailConfirmed = true,
                },
                new ApiUser
                {
                    Id = "f52522f4-0329-4037-a3c5-219abe6b80d5",
                    Email = "user2@broperty.com",
                    NormalizedEmail = "USER2@BROPERTY.COM",
                    UserName = "user2@broperty.com",
                    NormalizedUserName = "USER2@BROPERTY.COM",
                    FirstName = "Adam",
                    LastName = "Abrahamsson",
                    PasswordHash = "AQAAAAIAAYagAAAAEBX1pIrj+1YNKaog05C+oOx9U5r/rvnyN4SvLNfSqUr1zL54+iXnda0ujBN9v6wdeQ==",
                    SecurityStamp = "26041623-1de5-4636-b59d-d15736238599",
                    ConcurrencyStamp = "9cb56f6a-a523-4735-9e30-5ef24036dcf4",
                    EmailConfirmed = true,
                },
                new ApiUser
                {
                    Id = "f8b4f95c-02fe-40cc-b73d-36c0f7ac786f",
                    Email = "user3@broperty.com",
                    NormalizedEmail = "USER3@BROPERTY.COM",
                    UserName = "user3@broperty.com",
                    NormalizedUserName = "USER3@BROPERTY.COM",
                    FirstName = "Nina",
                    LastName = "Tudorsson",
                    PasswordHash = "AQAAAAIAAYagAAAAEBX1pIrj+1YNKaog05C+oOx9U5r/rvnyN4SvLNfSqUr1zL54+iXnda0ujBN9v6wdeQ==",
                    SecurityStamp = "308019e8-6f74-4a57-8722-0b1e407004a3",
                    ConcurrencyStamp = "8a9fb63f-80cb-4908-bb9f-a5aad2e8db93",
                    EmailConfirmed = true,
                },
                new ApiUser
                {
                    Id = "9c9da7da-4b24-459f-9e27-182c1e7b1d39",
                    Email = "user4@broperty.com",
                    NormalizedEmail = "USER4@BROPERTY.COM",
                    UserName = "user4@broperty.com",
                    NormalizedUserName = "USER4@BROPERTY.COM",
                    FirstName = "Leif",
                    LastName = "Thorsson",
                    PasswordHash = "AQAAAAIAAYagAAAAEBX1pIrj+1YNKaog05C+oOx9U5r/rvnyN4SvLNfSqUr1zL54+iXnda0ujBN9v6wdeQ==",
                    SecurityStamp = "77eab9a2-f47a-4e6f-bf92-d9db56cff596",
                    ConcurrencyStamp = "b85fdef9-583e-44fb-8e97-2d2997af08d6",
                    EmailConfirmed = true,
                }
            );

            // User roles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "da73186d-928a-4e7b-af8e-d69ebe4ea2c9",
                    RoleId = "5fb43755-efa6-428e-8f70-024d3294c7b6"
                },
                new IdentityUserRole<string>
                {
                    UserId = "e537ba2e-a85f-4c2e-bd43-2940963f7856",
                    RoleId = "bc472e9f-773c-4e71-a524-f37911680d76"
                },
                new IdentityUserRole<string>
                {
                    UserId = "f52522f4-0329-4037-a3c5-219abe6b80d5",
                    RoleId = "bc472e9f-773c-4e71-a524-f37911680d76"
                },
                new IdentityUserRole<string>
                {
                    UserId = "f8b4f95c-02fe-40cc-b73d-36c0f7ac786f",
                    RoleId = "bc472e9f-773c-4e71-a524-f37911680d76"
                },
                new IdentityUserRole<string>
                {
                    UserId = "9c9da7da-4b24-459f-9e27-182c1e7b1d39",
                    RoleId = "bc472e9f-773c-4e71-a524-f37911680d76"
                }
            );

            // Categories 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Lägenhet" },
                new Category { Id = 2, CategoryName = "Villa" },
                new Category { Id = 3, CategoryName = "Radhus" },
                new Category { Id = 4, CategoryName = "Bostadsrätt" },
                new Category { Id = 5, CategoryName = "Hyresrätt" },
                new Category { Id = 6, CategoryName = "Fritidshus" },
                new Category { Id = 7, CategoryName = "Stuga" },
                new Category { Id = 8, CategoryName = "Kollektivboende" },
                new Category { Id = 9, CategoryName = "Studentboende" }
            );

            // Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, CityName = "Stockholm" },
                new City { Id = 2, CityName = "Göteborg" },
                new City { Id = 3, CityName = "Malmö" },
                new City { Id = 4, CityName = "Uppsala" },
                new City { Id = 5, CityName = "Luleå" },
                new City { Id = 6, CityName = "Örebro" }
            );

            // Realtor Firms
            modelBuilder.Entity<RealtorFirm>().HasData(
                new RealtorFirm
                {
                    Id = 1,
                    CompanyName = "Broperty Bros",
                    Description = "En modern mäklarfirma med fokus på teknik och AI.",
                    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2ZjXY0_53ngWuJweTB5_n6Ogvo3_FsHh3lw&s",
                    WebsiteUrl = "https://www.bostaden.umea.se"
                },
                new RealtorFirm
                {
                    Id = 2,
                    CompanyName = "Mäklarkompaniet",
                    Description = "Traditionellt kunnande, moderna lösningar.",
                    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQfuELyshYBonAgRjJs86D0W7xPATcqIx48nw&s",
                    WebsiteUrl = "https://www.hudikhem.se"
                },
                new RealtorFirm
                {
                    Id = 3,
                    CompanyName = "Fastighetsmästarna",
                    Description = "Specialister på bostäder i hela Sverige.",
                    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnxZygU3x6zsKO3937icA5wDGg0UbijK1CxA&s",
                    WebsiteUrl = "https://heimstaden.com/se/"
                }
            );

            // Realtors
            modelBuilder.Entity<Realtor>().HasData(
                new Realtor
                {
                    Id = 1,
                    FirstName = "Marcus",
                    LastName = "Friberg",
                    PhoneNumber = "0705712647",
                    Email = "markus@bropertybros.se",
                    ProfileUrl = "https://media.licdn.com/dms/image/v2/D4D03AQEYZfjOaaV_QA/profile-displayphoto-shrink_800_800/profile-displayphoto-shrink_800_800/0/1719018397094?e=1750896000&v=beta&t=7Tc6mYQarQ62J6tfvYWlA5wLSLsxO-x5_eIlfPkYWIw",
                    RealtorFirmId = 1,
                    UserId = "e537ba2e-a85f-4c2e-bd43-2940963f7856"
                },
                new Realtor
                {
                    Id = 2,
                    FirstName = "Sanna",
                    LastName = "Mäklarsson",
                    PhoneNumber = "0731234567",
                    Email = "sanna@bropertybros.se",
                    ProfileUrl = "https://images.ctfassets.net/h6goo9gw1hh6/2sNZtFAWOdP1lmQ33VwRN3/24e953b920a9cd0ff2e1d587742a2472/1-intro-photo-final.jpg?w=1200&h=992&fl=progressive&q=70&fm=jpg",
                    RealtorFirmId = 1,
                    UserId = "f52522f4-0329-4037-a3c5-219abe6b80d5"
                },
                new Realtor
                {
                    Id = 3,
                    FirstName = "Erik",
                    LastName = "Fast",
                    PhoneNumber = "0704455667",
                    Email = "erik@maklarkompaniet.se",
                    ProfileUrl = "https://newprofilepic.photo-cdn.net//assets/images/article/profile.jpg?90af0c8",
                    RealtorFirmId = 2,
                    UserId = "f8b4f95c-02fe-40cc-b73d-36c0f7ac786f"
                },
                new Realtor
                {
                    Id = 4,
                    FirstName = "Anna",
                    LastName = "Sund",
                    PhoneNumber = "0761122334",
                    Email = "anna@fastighetsmastarna.se",
                    ProfileUrl = "https://media.istockphoto.com/id/1682296067/photo/happy-studio-portrait-or-professional-man-real-estate-agent-or-asian-businessman-smile-for.jpg?s=612x612&w=0&k=20&c=9zbG2-9fl741fbTWw5fNgcEEe4ll-JegrGlQQ6m54rg=",
                    RealtorFirmId = 3,
                    UserId = "9c9da7da-4b24-459f-9e27-182c1e7b1d39"
                }
                
            );

            // Properties
            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Address = "Exempelgatan 12",
                    Price = 4500000,
                    MonthlyFee = 3500,
                    YearlyFee = 42000,
                    LivingAreaKvm = 85,
                    AncillaryAreaKvm = 10,
                    LandAreaKvm = 0,
                    Description = "Fin bostadsrätt i centrala Stockholm.",
                    NumberOfRooms = 3,
                    BuildYear = 2010,
                    ImageUrls = new List<string>() { "https://coralhomes.com.au/wp-content/uploads/Grange-258Q-Harmony-Lodge-Facade-2-1190x680.jpg" },
                    CreatedAt = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc),
                    RealtorId = 1,
                    CityId = 1,
                    CategoryId = 4
                },
                new Property
                {
                    Id = 2,
                    Address = "Villavägen 7",
                    Price = 6700000,
                    MonthlyFee = 0,
                    YearlyFee = 12000,
                    LivingAreaKvm = 140,
                    AncillaryAreaKvm = 30,
                    LandAreaKvm = 500,
                    Description = "Stor villa med trädgård och garage.",
                    NumberOfRooms = 5,
                    BuildYear = 1995,
                    ImageUrls = new List<string>() { "https://www.thehousedesigners.com/images/plans/01/JBZ/bulk/4382/2428-dusk-render.webp" },
                    CreatedAt = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc),
                    RealtorId = 2,
                    CityId = 2,
                    CategoryId = 2
                },
                new Property
                {
                    Id = 3,
                    Address = "Sommarvägen 3",
                    Price = 2800000,
                    MonthlyFee = 2000,
                    YearlyFee = 24000,
                    LivingAreaKvm = 70,
                    AncillaryAreaKvm = 5,
                    LandAreaKvm = 0,
                    Description = "Ljus och modern lägenhet nära havet.",
                    NumberOfRooms = 2,
                    BuildYear = 2018,
                    ImageUrls = new List<string>() { "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?q=80\u0026w=1170\u0026auto=format\u0026fit=crop\u0026ixlib=rb-4.0.3\u0026ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    CreatedAt = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc),
                    RealtorId = 3,
                    CityId = 3,
                    CategoryId = 1
                },
                new Property
                {
                    Id = 4,
                    Address = "Stugvägen 1",
                    Price = 1600000,
                    MonthlyFee = 0,
                    YearlyFee = 10000,
                    LivingAreaKvm = 45,
                    AncillaryAreaKvm = 15,
                    LandAreaKvm = 1000,
                    Description = "Mysig stuga i skogsmiljö.",
                    NumberOfRooms = 2,
                    BuildYear = 1980,
                    ImageUrls = new List<string>() { "https://static.schumacherhomes.com/umbraco/media/wvflutbh/image4.jpg?format=webp", "https://static.schumacherhomes.com/umbraco/media/ytthzjth/image3.jpg?format=webp", "https://static.schumacherhomes.com/umbraco/media/4r4pxnt5/image11.jpg?format=webp" },
                    CreatedAt = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc),
                    RealtorId = 4,
                    CityId = 5,
                    CategoryId = 7
                }
            );
        }
    }
}
