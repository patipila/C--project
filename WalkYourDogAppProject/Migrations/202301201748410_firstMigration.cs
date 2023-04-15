namespace WalkYourDogAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertModels", "DogInf_DogId", "dbo.DogModels");
            DropForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels");
            DropIndex("dbo.AdvertModels", new[] { "Dog_DogId" });
            DropIndex("dbo.AdvertModels", new[] { "DogInf_DogId" });
            DropColumn("dbo.AdvertModels", "DogId");
            RenameColumn(table: "dbo.AdvertModels", name: "Dog_DogId", newName: "DogId");
            AlterColumn("dbo.AdvertModels", "DogId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertModels", "DogId");
            AddForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels", "DogId", cascadeDelete: true);
            DropColumn("dbo.AdvertModels", "DogInf_DogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertModels", "DogInf_DogId", c => c.Int());
            DropForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels");
            DropIndex("dbo.AdvertModels", new[] { "DogId" });
            AlterColumn("dbo.AdvertModels", "DogId", c => c.Int());
            RenameColumn(table: "dbo.AdvertModels", name: "DogId", newName: "Dog_DogId");
            AddColumn("dbo.AdvertModels", "DogId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertModels", "DogInf_DogId");
            CreateIndex("dbo.AdvertModels", "Dog_DogId");
            AddForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels", "DogId");
            AddForeignKey("dbo.AdvertModels", "DogInf_DogId", "dbo.DogModels", "DogId");
        }
    }
}
