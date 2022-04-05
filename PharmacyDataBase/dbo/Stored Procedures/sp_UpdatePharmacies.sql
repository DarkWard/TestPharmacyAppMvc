-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create procedure [dbo].[sp_UpdatePharmacies]
	@itemID int,
	@name nvarchar(MAX),
    @stateCode nvarchar(MAX),
    @address nvarchar(MAX),
    @contactEmail nvarchar(MAX),
    @contactPhone nvarchar(MAX)
as
    update Pharmacies set
        Name = @name,
        StateCode = @stateCode,
        Address = @address,
        ContactEmail = @contactEmail,
        ContactPhone = @contactPhone
    where id = @itemID
