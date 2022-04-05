-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create procedure [dbo].[sp_InsertToPharmacies]
    @name nvarchar(MAX),
    @stateCode nvarchar(MAX),
    @address nvarchar(MAX),
    @contactEmail nvarchar(MAX),
    @contactPhone nvarchar(MAX)
as
    insert into Pharmacies (Name, StateCode, Address, ContactEmail, ContactPhone)
    values (@name, @stateCode, @address, @contactEmail, @contactPhone)
