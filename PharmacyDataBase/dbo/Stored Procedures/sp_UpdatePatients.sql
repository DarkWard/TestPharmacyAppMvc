
create procedure [dbo].[sp_UpdatePatients]
	@itemId int,
	@firstName nvarchar(MAX),
    @lastName nvarchar(MAX),
    @stateCode nvarchar(MAX),
    @pharmacyName nvarchar(MAX),
    @pharmacyAssignDate nvarchar(MAX)
as
    update Patients set 
        FirstName = @firstName,
        LastName = @lastName,
        StateCode = @stateCode,
        PharmacyName = @pharmacyName,
        PharmacyAssignDate = @pharmacyAssignDate
    where id = @itemId
