create procedure [dbo].[sp_RemoveFromPatients]
	@itemId int 
as
	delete from Patients where id=@itemId
