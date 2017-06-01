namespace ImageBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 24),
                        ThemeBody = c.String(maxLength: 255),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        OptionId = c.Int(nullable: false),
                        CountPost = c.Int(nullable: false),
                        CountFile = c.Int(nullable: false),
                        CountUserSee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OptionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 24),
                        Password = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostName = c.String(maxLength: 24),
                        PostBody = c.String(maxLength: 255),
                        Star = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Theme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Themes", t => t.Theme_Id)
                .Index(t => t.UserId)
                .Index(t => t.Theme_Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        SubName = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 20),
                        Sex = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lock = c.Boolean(nullable: false),
                        Star = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        User_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.User_Id1 })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserUsers", new[] { "User_Id1" });
            DropIndex("dbo.UserUsers", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Theme_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "ProfileId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Themes", new[] { "OptionId" });
            DropIndex("dbo.Themes", new[] { "UserId" });
            DropForeignKey("dbo.UserUsers", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Theme_Id", "dbo.Themes");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Themes", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Themes", "UserId", "dbo.Users");
            DropTable("dbo.UserUsers");
            DropTable("dbo.Options");
            DropTable("dbo.Profiles");
            DropTable("dbo.Posts");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Themes");
        }
    }
}
