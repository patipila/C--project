CREATE TABLE [dbo].[AdvertModels] (
    [AdvertId]         INT            IDENTITY (1, 1) NOT NULL,
    [AdvertName]       NVARCHAR (MAX) NULL,
    [AdvertPrize]      INT            NOT NULL,
    [AdvertDate]       DATETIME       NOT NULL,
    [WhenDate]         DATETIME       NOT NULL,
    [AdvertTime]       INT            NOT NULL,
    [AdvertContent]    NVARCHAR (MAX) NULL,
    [DogId]            INT            NOT NULL,
    [Dog_DogId]        INT            NULL,
    [OwnerInf_OwnerId] INT            NULL,
    CONSTRAINT [PK_dbo.AdvertModels] PRIMARY KEY CLUSTERED ([AdvertId] ASC),
    CONSTRAINT [FK_dbo.AdvertModels_dbo.DogModels_Dog_DogId] FOREIGN KEY ([Dog_DogId]) REFERENCES [dbo].[DogModels] ([DogId]),
    CONSTRAINT [FK_dbo.AdvertModels_dbo.OwnerModels_OwnerInf_OwnerId] FOREIGN KEY ([OwnerInf_OwnerId]) REFERENCES [dbo].[OwnerModels] ([OwnerId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Dog_DogId]
    ON [dbo].[AdvertModels]([Dog_DogId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerInf_OwnerId]
    ON [dbo].[AdvertModels]([OwnerInf_OwnerId] ASC);

