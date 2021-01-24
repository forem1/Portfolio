
CREATE TABLE [dbo].Checks
(
	[CheckKey] [int] not null IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[DataTime] [datetime]  NOT NULL DEFAULT  CURRENT_TIMESTAMP,
	--Временная переменная, обязательная для заполнения
	[Cost] [int]  NOT NULL,
	--Целочисленная переменная, обязательная для заполнения с проверкой больше 0

	constraint [PK_Checks] primary key clustered ([CheckKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [CH_Cost] check ([Cost] >= 0)
	--Проверка на положительный знак числа
)
go


CREATE TABLE [dbo].Inventary
(
	[InventaryKey] int IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Name] [varchar] (50)  NOT NULL ,
	--Cтроковая переменная с размерностью в 50 символов, обязательная для заполнения
	[Position] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[Quantity] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[FullCost] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[StorageTypeKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	
	constraint [PK_Inventary] primary key clustered ([InventaryKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [CH_Position] check ([Position] >= 0),
	--Проверка на положительный знак числа
	constraint [CH_Quantity] check ([Quantity] >= 0),
	--Проверка на положительный знак числа
	constraint [CH_FullCost] check ([FullCost] >= 0),
	--Проверка на положительный знак числа
	constraint [UQ_InventaryName] unique ([Name]), 
	--Проверка на уникальность

	constraint [FK_Storage_Type_Key] foreign key ([StorageTypeKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[StorageType]([StorageTypeKey]),
	--Ссылка на значение первичного ключа родительской таблицы
)
go



CREATE TABLE [dbo].Materials
(
	[MaterialKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[OrderKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[CheckKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[InventaryKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	
	constraint [PK_Inventary] primary key clustered ([InventaryKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [FK_Inventary_Key] foreign key ([InventaryKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[Inventary]([InventaryKey]),
	--Ссылка на значение первичного ключа родительской таблицы
	constraint [FK_Order_Key] foreign key ([OrderKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[Orders]([OrderKey]),
	--Ссылка на значение первичного ключа родительской таблицы
	constraint [FK_Check_Key] foreign key ([CheckKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[Checks]([CheckKey]),
	--Ссылка на значение первичного ключа родительской таблицы
)
go


CREATE TABLE [dbo].Orders
(
	[OrderKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Name] [varchar] (20)  NOT NULL ,
	--Cтроковая переменная с размерностью в 50 символов, обязательная для заполнения
	[Task] [text]  NULL ,
	--Текстовая переменная
	[WorkerKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[TypeWorkKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[WorkStatusKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	[CheckKey] [int]  NOT NULL ,
	--Целочисленное обязательное для заполнения поле
	
	constraint [PK_Orders] primary key clustered ([OrderKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	
	constraint [FK_CheckKey] foreign key ([CheckKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[Checks]([CheckKey]),
	--Ссылка на значение первичного ключа родительской таблицы

	constraint [FK_WorkerKey] foreign key ([WorkerKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[Workers]([WorkerKey]),
	--Ссылка на значение первичного ключа родительской таблицы
	constraint [FK_TypeWorkKey] foreign key ([TypeWorkKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[WorkType]([TypeWorkKey]),
	--Ссылка на значение первичного ключа родительской таблицы
	constraint [FK_WorkStatusKey] foreign key ([WorkStatusKey])
	--Ограничение на поле с типом "Внешний ключ" с указанием какое поле в таблице является внешним ключом
	references [dbo].[WorkStatus]([WorkStatusKey])
	--Ссылка на значение первичного ключа родительской таблицы
)
go


CREATE TABLE [dbo].StorageType
(
	[StorageTypeKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Name] [varchar] (20)  NOT NULL,
	--Cтроковая переменная с размерностью в 20 символов, обязательная для заполнения
	
	constraint [PK_StorageType] primary key clustered ([StorageTypeKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [UQ_StorageType] unique ([Name]), 
	--Проверка на уникальность
)
go


CREATE TABLE [dbo].Workers
(
	[WorkerKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Surname] [varchar] (50)  NOT NULL ,
	--Cтроковая переменная с размерностью в 50 символов, обязательная для заполнения
	[Name] [varchar] (50)  NOT NULL ,
	--Cтроковая переменная с размерностью в 50 символов, обязательная для заполнения
	[Patronymic] [varchar] (50)  NULL default('-'),
	--Строковая переменная, необязательная для заполнения с свойством значения по умолчанию
	
	constraint [PK_Workers] primary key clustered ([WorkerKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
)
go


CREATE TABLE [dbo].WorkStatus
(
	[WorkStatusKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Name] [varchar] (20)  NOT NULL ,
	--Cтроковая переменная с размерностью в 20 символов, обязательная для заполнения
	
	constraint [PK_WorkStatus] primary key clustered ([WorkStatusKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [UQ_WorkStatus] unique ([Name]), 
	--Проверка на уникальность
)
go


CREATE TABLE [dbo].WorkType
(
	[TypeWorkKey] [int] IDENTITY (1,1) ,
	--Целочисленное обязательное для заполнения поле с автоинкрементом на единицу с начальным значением 1
	[Name] [varchar] (20)  NOT NULL ,
	--Cтроковая переменная с размерностью в 20 символов, обязательная для заполнения
	
	constraint [PK_WorkType] primary key clustered ([TypeWorkKey] ASC) on [PRIMARY],
	-- Ограничение на поле с типом первичный ключ, значения первичного ключа идут по возрастанию и находятся в кластаре в группе ключей PRIMARY
	constraint [UQ_WorkType] unique ([Name]), 
	--Проверка на уникальность
)
go