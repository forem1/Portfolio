create or alter trigger [dbo].[CheckDeletedTrigger] on [dbo].[Checks]
after delete --Нужные операции для выполнения триггера
as
delete from [dbo].[Orders] where CheckKey = SELECT CheckKey
FROM DELETED
go
