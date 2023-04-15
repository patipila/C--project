namespace WalkYourDogAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertModels",
                c => new
                    {
                        AdvertId = c.Int(nullable: false, identity: true),
                        AdvertName = c.String(),
                        AdvertPrize = c.Int(nullable: false),
                        AdvertDate = c.DateTime(nullable: false),
                        WhenDate = c.DateTime(nullable: false),
                        AdvertTime = c.Int(nullable: false),
                        AdvertContent = c.String(),
                        DogId = c.Int(nullable: false),
                        Dog_DogId = c.Int(),
                        
                        OwnerInf_OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.AdvertId)
                .ForeignKey("dbo.DogModels", t => t.Dog_DogId)
               
                .ForeignKey("dbo.OwnerModels", t => t.OwnerInf_OwnerId)
                .Index(t => t.Dog_DogId)
                
                .Index(t => t.OwnerInf_OwnerId);
            
            CreateTable(
                "dbo.DogModels",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        DogName = c.String(),
                        DogAge = c.String(),
                        DogSize = c.Int(nullable: false),
                        ActivityDemand = c.Int(nullable: false),
                        DescriptionD = c.String(),
                        DogGender = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                        OwnerSurname = c.String(),
                        OwnerDateOfBirth = c.DateTime(nullable: false),
                        OwnerEmail = c.String(),
                        OwnerPhone = c.String(),
                        OwnerGender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.WalkerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WalkerName = c.String(),
                        WalkerSurname = c.String(),
                        WalkerDateOfBirth = c.DateTime(nullable: false),
                        WalkerEmail = c.String(),
                        WalkerPhone = c.String(),
                        DescriptionW = c.String(),
                        WalkerGender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertModels", "OwnerInf_OwnerId", "dbo.OwnerModels");
            DropForeignKey("dbo.AdvertModels", "Dog_DogId", "dbo.DogModels");
            DropForeignKey("dbo.DogModels", "OwnerId", "dbo.OwnerModels");
            DropIndex("dbo.DogModels", new[] { "OwnerId" });
            DropIndex("dbo.AdvertModels", new[] { "OwnerInf_OwnerId" });
            
            DropIndex("dbo.AdvertModels", new[] { "Dog_DogId" });
            DropTable("dbo.WalkerModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.DogModels");
            DropTable("dbo.AdvertModels");
        }
    }
}
