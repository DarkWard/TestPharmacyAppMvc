CREATE TABLE [dbo].[Patients] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]          NVARCHAR (MAX) NOT NULL,
    [LastName]           NVARCHAR (MAX) NOT NULL,
    [StateCode]          NVARCHAR (MAX) NOT NULL,
    [PharmacyName]       NVARCHAR (MAX) NOT NULL,
    [PharmacyAssignDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

