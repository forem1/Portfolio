create or alter function [dbo].[Order_Information](@OrderKey [int]) --Создание функции
returns table --Возвращаемая таблица
as
	return(select [dbo].[WorkType].[Name] as "Вид работы",
	[dbo].[WorkStatus].[Name] as "Статус заказа", 
	[dbo].[Workers].[Surname] as "Исполнитель",
	CONVERT([varchar] (max),[dbo].[Checks].[Cost]) + ' руб.' as "Цена",
	from [dbo].[Orders]
	inner join [dbo].[WorkType] on [KeyWorkType] = [WorkTypeKey]
	inner join [dbo].[WorkStatus] on [KeyWorkStatus] = [WorkStatusKey]
	inner join [dbo].[Workers] on [KeyWorkers] = [WorkersKey]
	inner join [dbo].[Checks] on [KeyChecks] = [ChecksKey]
	where [OrderKey] = @OrderKey)
go
select * from [dbo].[Order_Information](1) --Вызов функции


create or alter function [dbo].[Order_Text](@OrderKey [int]) --Создание функции
returns [text] --Возвращаемый тип
with execute as caller
as
begin
	declare @TextOrder [text] = (select [dbo].[Orders].[Task] from [dbo].[Orders]
	where [dbo].[Orders].[OrderKey] = @OrderKey)
	return(@TextOrder) --Возвращение значения
end
go
select [dbo].[Order_Text](1) --Вызов функции
