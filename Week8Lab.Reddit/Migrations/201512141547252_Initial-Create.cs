namespace Week8Lab.Reddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        Up = c.Int(nullable: false),
                        Down = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
