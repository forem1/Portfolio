create or alter view [dbo].[Materials_View] ("Код материалов", "Наименование", "Код инвентаря")
as
select
[dbo].[Materials].[MaterialKey], --Получение кода материалов
[dbo].[Orders].[Name], --Получение имени заказа
[dbo].[Inventary].[InventaryKey], --Получение кода инвентаря
from [dbo].[Materials]
inner join [dbo].[Materials] on [KeyMaterials] = [MaterialKey]
inner join [dbo].[Orders] on [KeyOrders] = [OrderKey]
inner join [dbo].[Inventary] on [KeyInventary] = [InventaryKey]
go




create or alter view [dbo].[Order_View] ("ФИО сотрудника", "Наименование", "Статус выполнения", "Чек")
as
select
[dbo].[Workers].[Surname] + ' ' + substring([dbo].[Workers].[Name], 1, 1) + '.' + substring([dbo].[Workers].[Patronymic], 1, 1) + '.',
--Получение ФИО сотрудника
[dbo].[Orders].[Name], --Получение наименования
[dbo].[WorkStatus].[Name], --Получение статуса
[dbo].[Checks].[CheckKey] --Получение номера чека
from [dbo].[Orders]
inner join [dbo].[Workers] on [NameWorkers] = [WorkerKey]
inner join [dbo].[Orders] on [NameOrders] = [OrderKey]
inner join [dbo].[WorkStatus] on [NameStatus] = [WorkStatusKey]
inner join [dbo].[Checks] on [KeyCheck] = [CheckKey]
go


