namespace WalkYourDogAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertModels", "advert_AdvertId", "dbo.AdvertModels");
            DropForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels");
            DropIndex("dbo.AdvertModels", new[] { "advert_AdvertId" });
            DropIndex("dbo.AdvertModels", new[] { "Dog_DogId" });
            RenameColumn(table: "dbo.AdvertModels", name: "Dog_DogId", newName: "DogId");
            AlterColumn("dbo.AdvertModels", "DogId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertModels", "DogId");
            AddForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels", "DogId", cascadeDelete: true);
            DropColumn("dbo.AdvertModels", "advert_AdvertId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertModels", "advert_AdvertId", c => c.Int());
            DropForeignKey("dbo.AdvertModels", "DogId", "dbo.DogModels");
            DropIndex("dbo.AdvertModels", new[] { "DogId" });
            AlterColumn("dbo.AdvertModels", "DogId", c => c.Int());
            RenameColumn(table: "dbo.AdvertModels", name: "DogId", newName: "Dog_DogId");
            CreateIndex("dbo.AdvertModels", "Dog_DogId");
            CreateIndex("dbo.AdvertModels", "advert_AdvertId");
            AddForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels", "DogId");
            AddForeignKey("dbo.AdvertModels", "advert_AdvertId", "dbo.AdvertModels", "AdvertId");
        }
    }
}
