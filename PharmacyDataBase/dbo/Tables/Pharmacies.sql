CREATE TABLE [dbo].[Pharmacies] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [StateCode]    NVARCHAR (MAX) NOT NULL,
    [Address]      NVARCHAR (MAX) NOT NULL,
    [ContactEmail] NVARCHAR (MAX) NOT NULL,
    [ContactPhone] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Pharmacies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

