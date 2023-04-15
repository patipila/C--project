namespace WalkYourDogAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels");
            DropIndex("dbo.AdvertModels", new[] { "DogId" });
            RenameColumn(table: "dbo.AdvertModels", name: "DogId", newName: "Dog_DogId");
            AddColumn("dbo.AdvertModels", "advert_AdvertId", c => c.Int());
            AlterColumn("dbo.AdvertModels", "Dog_DogId", c => c.Int());
            CreateIndex("dbo.AdvertModels", "advert_AdvertId");
            CreateIndex("dbo.AdvertModels", "Dog_DogId");
            AddForeignKey("dbo.AdvertModels", "advert_AdvertId", "dbo.AdvertModels", "AdvertId");
            AddForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels", "DogId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels");
            DropForeignKey("dbo.AdvertModels", "advert_AdvertId", "dbo.AdvertModels");
            DropIndex("dbo.AdvertModels", new[] { "Dog_DogId" });
            DropIndex("dbo.AdvertModels", new[] { "advert_AdvertId" });
            AlterColumn("dbo.AdvertModels", "Dog_DogId", c => c.Int(nullable: false));
            DropColumn("dbo.AdvertModels", "advert_AdvertId");
            RenameColumn(table: "dbo.AdvertModels", name: "Dog_DogId", newName: "DogId");
            CreateIndex("dbo.AdvertModels", "DogId");
            AddForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels", "DogId", cascadeDelete: true);
        }
    }
}
