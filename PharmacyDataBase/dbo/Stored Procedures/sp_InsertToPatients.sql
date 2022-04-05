
CREATE procedure [dbo].[sp_InsertToPatients]
    @firstName nvarchar(MAX),
    @lastName nvarchar(MAX),
    @stateCode nvarchar(MAX),
    @pharmacyName nvarchar(MAX),
    @pharmacyAssignDate nvarchar(MAX)
as
    insert into Patients (FirstName, LastName, StateCode, PharmacyName, PharmacyAssignDate)
    values (@firstName, @lastName, @stateCode, @pharmacyName, @pharmacyAssignDate)
