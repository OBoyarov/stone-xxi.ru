USE [db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE function [dbo].[f_existsday] 
(
	@day date
) 
returns float as
begin
	return (
			select iif(count(1) > 0, 1, 0) from [db].[dbo].[cbr_data] where [datereq] = @day
			)
end

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE function [dbo].[f_get_valute] 
(
  @reqdate date,
  @reqvalute nvarchar(3)
) 
returns float as
begin
	return (
			select
				cb.[value] / ci.[Nominal] as [value]
			from
				[dbo].[cbr_data] cb
			left join
				[dbo].[cbr_items] ci
			on
				cb.charcode = ci.ISO_Char_Code
			where
				[charcode] = @reqvalute
				and
				[datereq] = @reqdate
			)
end

GO
