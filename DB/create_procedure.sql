USE [db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[p_get_valutes]
as
	select distinct
		ci.[Name] + ' [' + cd.[charcode] + ']' as [Valute]
	from 
		[dbo].[cbr_data] cd
	left join
		[dbo].[cbr_items] ci
	on
		cd.[charcode] = ci.[ISO_Char_Code]
GO
