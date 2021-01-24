create procedure [dbo].[Checks_Insert]
@DataTime [datetime], @Cost [int]
as
insert into [dbo].[Checks] (DataTime, Cost)
values (@DataTime, @Cost)
go -- Процедура добавления записи

create procedure [dbo].[Checks_Delete]
@CheckKey [int]
as
delete from [dbo].[Checks]
where CheckKey = @CheckKey
go -- Процедура удаления записи по номеру записи



create procedure [dbo].[Inventary_Insert]
@Name [varchar] (50), @Position [int], @Quantity [int], @FullCost [int], @StorageTypeKey [int]
as
insert into [dbo].[Inventary] (Name, Position, Quantity, FullCost, StorageTypeKey)
values (@Name, @Position, @Quantity, @FullCost, @StorageTypeKey)
go -- Процедура добавления записи

create procedure [dbo].[Inventary_Delete]
@InventaryKey [int]
as
delete from [dbo].[Inventary]
where InventaryKey = @InventaryKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[Inventary_Update]
@InventaryKey [int], @Name [varchar] (50), @Position [int], @Quantity [int], @FullCost [int], @StorageTypeKey [int]
as
update [dbo].[Inventary] set
Name = @Name,
Position = @Position,
Quantity = @Quantity,
FullCost = @FullCost,
StorageTypeKey = @StorageTypeKey
where InventaryKey = @InventaryKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[Materials_Insert]
@OrderKey [int], @CheckKey [int], @InventaryKey [int]
as
insert into [dbo].[Materials] (OrderKey, CheckKey, InventaryKey)
values (@OrderKey, @CheckKey, @InventaryKey)
go -- Процедура добавления записи

create procedure [dbo].[Materials_Delete]
@MaterialKey [int]
as
delete from [dbo].[Materials]
where MaterialKey = @MaterialKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[Materials_Update]
@MaterialKey [int], @OrderKey [int], @CheckKey [int], @InventaryKey [int]
as
update [dbo].[Materials] set
OrderKey = @OrderKey,
CheckKey = @CheckKey,
InventaryKey = @InventaryKey
where MaterialKey = @MaterialKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[Orders_Insert]
@Name [varchar] (20), @Task [text], @WorkerKey [int], @TypeWorkKey [int], @WorkStatusKey [int], @CheckKey [int]
as
insert into [dbo].[Orders] (Name, Task, WorkerKey, TypeWorkKey, WorkStatusKey, CheckKey)
values (@Name, @Task, @WorkerKey, @TypeWorkKey, @WorkStatusKey, @CheckKey)
go -- Процедура добавления записи

create procedure [dbo].[Orders_Delete]
@OrderKey [int]
as
delete from [dbo].[Orders]
where OrderKey = @OrderKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[Orders_Update]
@OrderKey [int], @Name [varchar] (20), @Task [text], @WorkerKey [int], @TypeWorkKey [int], @WorkStatusKey [int], @CheckKey [int]
as
update [dbo].[Orders] set
Name = @Name,
Task = @Task,
WorkerKey = @WorkerKey,
TypeWorkKey = @TypeWorkKey,
WorkStatusKey = @WorkStatusKey,
CheckKey = @CheckKey
where OrderKey = @OrderKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[StorageType_Insert]
@Name [varchar] (20)
as
insert into [dbo].[StorageType] (Name)
values (@Name)
go -- Процедура добавления записи

create procedure [dbo].[StorageType_Delete]
@StorageTypeKey [int]
as
delete from [dbo].[StorageType]
where StorageTypeKey = @StorageTypeKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[StorageType_Update]
@StorageTypeKey [int], @Name [varchar] (20)
as
update [dbo].[StorageType] set
Name = @Name
where StorageTypeKey = @StorageTypeKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[Workers_Insert]
@Surname [varchar] (50), @Name [varchar] (50), @Patronymic [varchar] (50)
as
insert into [dbo].[Workers] (Surname, Name, Patronymic)
values (@Surname, @Name, @Patronymic)
go -- Процедура добавления записи

create procedure [dbo].[Workers_Delete]
@WorkerKey [int]
as
delete from [dbo].[Workers]
where WorkerKey = @WorkerKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[Workers_Update]
@WorkerKey [int], @Surname [varchar] (50), @Name [varchar] (50), @Patronymic [varchar] (50)
as
update [dbo].[Workers] set
Surname = @Surname,
Name = @Name,
Patronymic = @Patronymic
where WorkerKey = @WorkerKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[WorkStatus_Insert]
@Name [varchar] (20)
as
insert into [dbo].[WorkStatus] (Name)
values (@Name)
go -- Процедура добавления записи

create procedure [dbo].[WorkStatus_Delete]
@WorkStatusKey [int]
as
delete from [dbo].[WorkStatus]
where WorkStatusKey = @WorkStatusKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[WorkStatus_Update]
@WorkStatusKey [int], @Name [varchar] (20)
as
update [dbo].[WorkStatus] set
Name = @Name
where WorkStatusKey = @WorkStatusKey
go -- Процедура обновления записи по номеру записи



create procedure [dbo].[WorkType_Insert]
@Name [varchar] (20)
as
insert into [dbo].[WorkType] (Name)
values (@Name)
go -- Процедура добавления записи

create procedure [dbo].[WorkType_Delete]
@TypeWorkKey [int]
as
delete from [dbo].[WorkType]
where TypeWorkKey = @TypeWorkKey
go -- Процедура удаления записи по номеру записи

create procedure [dbo].[WorkType_Update]
@TypeWorkKey [int], @Name [varchar] (20)
as
update [dbo].[WorkType] set
Name = @Name
where TypeWorkKey = @TypeWorkKey
go -- Процедура обновления записи по номеру записи
