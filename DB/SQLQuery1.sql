set ansi_padding on--���������� ��� ������� � ������
go--����� ����������. ���������� - ��� ������� �� �� ������ ����������������� ��������� � ������ ���������������� ���������
set quoted_identifier on -- ������������� ����������� ������ �������� ���������
go
set ansi_nulls on --���������� ������ � ����� ������ ��� � ��������� 2017 �������
go

create database [P1_Employee_Base]--�������� ������� ��
go

use	[P1_Employee_Base]--���� ���� ������� ��� ��������� � ���������� �������
go

create table[dbo].[Employee]
(
	[ID_Employee] [int] not null identity(1,1),--������������� ����������� ��� ����������� ���� � ��������� �������������� � ��������� ��������� 1 � � ����� 1
	[First_name] [varchar] (30) not null,-- ����������� ����������� ��������� ���������� � ������������ 30 �������� ����������� ��� ����������
	[Name_employee] [varchar] (30) not null,
	[Middle_Name] [varchar] (30) null default('-')--c�������� ���������� �������������� ��� ���������� � ��������� �������� �� ���������

	constraint [PK_Employee] primary key clustered
	([ID_Employee] ASC) on [PRIMARY],
)
go

create table[dbo].[Post]
(
	[ID_Post] [int] not null identity(1,1),
	[Name_Post] [varchar] (50) not null,
	[Cost_Post] [decimal] (38,2) null default(0.0)--������������ ��� ������ � 38 ������ ��� ������ ����� � 2 ��������� ����� �������
	constraint [PK_Post] primary key clustered
	([ID_Post] ASC) on [PRIMARY],
	constraint [CH_Cost_Post] check ([Cost_Post]>=0.0),-- ����������� �� ���� � ��������� �� ����������� �������
	constraint [UQ_Name_Post] unique ([Name_Post])--����������� ���� � ��������� �� ������������ ��������� ��������
)
go

create table [dbo].[Combination]
(
	[ID_Combination] [int] not null identity(1,1),
	[Employee_ID] [int] not null,
	[Post_ID] [int] not null,
	[Part_Post] [decimal] (38,2) null default(0.0)

	constraint [PK_Combination] primary key clustered
	([ID_Combination] ASC) on [PRIMARY],
	constraint [CH_Part_Post] check ([Part_Post]>=0.0),
	constraint [FK_Employee_Combination] foreign key ([Employee_ID])
	references [dbo].[Employee]([ID_Employee]),
	constraint [FK_Post_Combination] foreign key ([Post_ID])--����������� �� ���� � ����� ������� ���� c ��������� ����� ���� � ������� �������� ������� ������
	references [dbo].[Post]([ID_Post])--c����� �� �������� ���������� ����� ������������ �������
	
)
go

create procedure [dbo].[Employee_update]
@ID_Employee [int], @First_name [varchar] (30), @Name_employee [varchar] (30), @Middle_Name [varchar] (30)
as
update [dbo].[Employee] set
 First_name = @First_name,
 Name_employee = @Name_employee,
 Middle_Name = @Middle_Name

 where ID_Employee=@ID_Employee
go

create procedure [dbo].[Employee_incert]
@First_name [varchar] (30), @Name_employee [varchar] (30), @Middle_Name [varchar] (30)
as
insert into [dbo].[Employee] (
First_name, 
Name_employee,
Middle_Name
)

values (
@First_name, @Name_employee, @Middle_Name
)
go


create procedure [dbo].[Post_update]
@ID_Post [int],@Name_Post [varchar] (30), @Cost_Post [decimal] (30)
as
update [dbo].[Post] set
 Name_Post = @Name_Post,
 Cost_Post = @Cost_Post

 where ID_Post=@ID_Post
go

create procedure [dbo].[Post_insert]
@Name_Post [varchar] (30), @Cost_Post [decimal] (30)
as
insert into [dbo].[Post] (
 Name_Post,
 Cost_Post
)

values (
 @Name_Post,
 @Cost_Post
)
go

create procedure [dbo].[Post_delete]
@ID_Post [int]
as
delete from [dbo].[Post] 
 where ID_Post=@ID_Post
go

create procedure [dbo].[Combination_update]
@ID_Combination [int], @Employee_ID [int], @Post_ID [int], @Part_Post [decimal] (30)
as
update [dbo].[Combination] set
 Employee_ID = @Employee_ID,
 Post_ID = @Post_ID,
 Part_Post = @Part_Post

 where ID_Combination=@ID_Combination
go

create procedure [dbo].[Combination_insert]
@Employee_ID [int], @Post_ID [int], @Part_Post [decimal] (30)
as
insert into [dbo].[Combination] (
Employee_ID,
Post_ID,
Part_Post
)

values (
@Employee_ID,
@Post_ID,
@Part_Post
)
go

create procedure [dbo].[Combination_delete]
@ID_Combination [int]
as
delete from [dbo].[Combination] 
 where ID_Combination=@ID_Combination
go


--DDL. ������� - ��� �����������, ������� ����� ����� ���������� ���������, ������� ����������� ���������� ���� �������, ���� �����-�� ��� ������
--�����������: ��������� ������� - ���������� ���� ������ (���� �������, ���� ������)
--create or alter function [dbo].<Name_Function> (null|[@<Parameter_Name> <Data_Type>,])
--return <Target_Data_Type> - ������������ ���
--with execute as caller - ������� ��������� �� ��������� �������
--as
--begin
--<Body_Function>
--return()
--end
--go
--����������� ��������� �������
--create ar alter function [dbo].<Name_Function> (null|[@<Parameter_Name> <Data_Type>,])
--returns table
--as
--<Body_Function>
--return()
--go
--����� ��������� ������� select [dbo].<Name_Function> (null|[@<Parameter_Name> <Data_Type>,])
--����� ��������� ������� select * from [dbo].<Name_Function> (null|[@<Parameter_Name> <Data_Type>,])
--������. ������� ��������� ����� �� ��������� ���������.