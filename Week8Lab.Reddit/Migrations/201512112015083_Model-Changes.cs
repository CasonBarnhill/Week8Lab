namespace Week8Lab.Reddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Posts");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Posts", "PostId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Posts", "Up", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Down", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "PostDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Posts", "PostId");
            DropColumn("dbo.Posts", "Id");
            DropColumn("dbo.Posts", "Like");
            DropColumn("dbo.Posts", "Dislike");
            DropTable("dbo.Accounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Dislike", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Posts");
            DropColumn("dbo.Posts", "PostDate");
            DropColumn("dbo.Posts", "Down");
            DropColumn("dbo.Posts", "Up");
            DropColumn("dbo.Posts", "PostId");
            DropTable("dbo.Users");
            AddPrimaryKey("dbo.Posts", "Id");
        }
    }
}
