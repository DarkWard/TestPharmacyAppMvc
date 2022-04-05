-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create procedure [dbo].[sp_RemoveFromPharmacies]
	@itemId int 
as
	delete from Pharmacies where id=@itemId
