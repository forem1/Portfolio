set ansi_padding on -- �������� ��������
go --����� ����������
set quoted_identifier on-- ���������� �������� �������� � �������
go
set ansi_nulls on --���������� ������ � ����� ������ null � ��������� 2017 �������
go

--create database [P1_Employee_Base] ��������� ������� ��
--go

use [P1_Employee_Base] --���� ����������� ��� ��������� � ������� �������
go

select * from [dbo].[Employee]
select [First_name], [Name_Employee], [Middle_Name] from [dbo].[Employee]
select [First_name] as "�������", SUBSTRING([Name_Employee], 1, 1) as "���", SUBSTRING([Middle_Name], 1, 1) as "��������" from [dbo].[Employee]
select [First_name] + ' ' + SUBSTRING([Name_Employee], 1, 1) + '.' + SUBSTRING([Middle_Name], 1, 1) + '.' as "������� �.�." from [dbo].[Employee]

select * from [dbo].[Combination]
--join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
--inner join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
--right join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
--left join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
--full outer join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
--cross join [dbo].[Employee]
select [dbo].[Employee].[First_name] + ' ' + SUBSTRING([dbo].[Employee].[Name_employee], 1, 1) + '.' + SUBSTRING([dbo].[Employee].[Middle_name], 1, 1) + '.' as "������ ����������",
[dbo].[Post].[Name_Post] + ', ����� �� ���������: ' + CONVERT([varchar] (max), [dbo].[Post].[Cost_Post]) + ' ���.' as "��������� - �����", 
CONVERT([varchar] (max), [dbo].[Post].[Cost_Post] * [dbo].[Combination].[Part_Post]) + ' ���.' as "�����" from [dbo].[Combination]
inner join [dbo].[Employee] on [Employee_ID] = [ID_Employee]
inner join [dbo].[Post] on [Post_ID] = [ID_Post]

/*create view [dbo].[Employee_Post] ("���������", "���������", "�����")
as
	select [dbo].[Employee].[First_name] + ' ' + SUBSTRING([dbo].[Employee].[Name_employee], 1, 1) + '.' + SUBSTRING([dbo].[Employee].[Middle_name], 1, 1) + '.' as "������ ����������",
	[dbo].[Post].[Name_Post] + ', ����� �� ���������: ' + CONVERT([varchar] (max), [dbo].[Post].[Cost_Post]) + ' ���.' as "��������� - �����", 
	CONVERT([varchar] (max), [dbo].[Post].[Cost_Post] * [dbo].[Combination].[Part_Post]) + ' ���.' as "�����" from [dbo].[Combination]
	inner join [dbo].[Employee] on [Employee_ID] = [ID_Employee]
	inner join [dbo].[Post] on [Post_ID] = [ID_Post]
go
select * from [dbo].[Employee_Post]*/

select * from [dbo].[Employee_Post]
select count(*) as "���������� �����" from [dbo].[Employee_Post]
select Sum(CONVERT([decimal] (38,2), substring([�����],1,LEN([�����])-5))) as "����� ����"

from [dbo].[Employee_Post]
select AVG(CONVERT([decimal] (38,2), substring([�����],1,LEN([�����])-5))) as "������� �������� ����"
from [dbo].[Employee_Post]
select ROUND(AVG(CONVERT([decimal] (38,2), substring([�����],1,LEN([�����])-5))),2) as "���������� �������� �������� ����"
from [dbo].[Employee_Post]
select * from [dbo].Employee_Post
select Max(CONVERT([decimal] (38,2), substring([�����],1,LEN([�����])-5))) as "��������"
from [dbo].[Employee_Post]
select * from [dbo].Employee_Post
select Min(CONVERT([decimal] (38,2), substring([�����],1,LEN([�����])-5))) as "�������"
from [dbo].[Employee_Post]

select len([���������]) as "����� ������" from [dbo].[Employee_Post]
select count([dbo].[Combination].[Employee_ID]) as "���������� �����������", [dbo].[Post].[Name_Post] as "�������� ���������" from [dbo].[Combination]
join [dbo].[Post] on [ID_Post] = [Post_ID]
group by [dbo].[Post].[Name_Post]
having count([dbo].[Combination].[Employee_ID])>1
select [dbo].[Post].[Name_Post] as "�������� ���������",
AVG([dbo].[Post].[Cost_Post]*[dbo].[Combination].[Part_Post]) as "������� ������" from [dbo].[Combination]
join [dbo].[Post] on [ID_Post] = [Post_ID]
group by [dbo].[Post].[Name_Post]


--������ � ������
declare @Date_Time_Now [datetime] -- declare - ���������� ���������� � ��������� �������� � ����
set @Date_Time_Now = GETDATE() -- ���������� ������� ���� � ����� � �������
select @Date_Time_Now
select GETDATE()
select FORMAT(@Date_Time_Now, 'dd.MM.yyyy hh-mm-ss')
declare @1_Date [datetime], @2_Date [datetime], @3_Date [datetime]
declare @1Date [Date] = '2019-10-24', @2Date [Date] = '2020-10-25', @3Date [Date] = '2020-10-26'
set @1_Date = @1Date
set @2_Date = @2Date
set @3_Date = @3Date
select @1_Date, @2_Date, @3_Date

select DATEDIFF(DAY, @1_Date, @3_Date)
select DATEDIFF(WEEK, @1_Date, @3_Date)
select DATEDIFF(YEAR, @1_Date, @3_Date)
select DATEDIFF(QUARTER, @1_Date, @3_Date)
select GETDATE(),DATEADD(YEAR,18,GETDATE())


-- ----------------------------------------------------------------------------------------------------------


--DDL. ������� - ��� �����������, ������� ����� ���� ���������� ���������, ������� ����������� ���������� ���� �������, ���� �����-�� ��� ������
--�����������: ��������� ������� - ���������� ���� ������ (���� �������, ���� ������)
--create or alter function [dbo].<Name_Function> (null)
--returns <Target_data_Type> - ������������ ���
--with execute as caller - ������� ��������� �� ��������� �������
--as
--begin
--<Body_Function>
--return()
--end
--go

--����������� ��������� �������
--create or alter function [dbo].<Name_Function> (null|[@<Paramener_Name>, <Data_Type>])
--returns table - ������������ ���
--as
--<Body_Function>
--return()
--go

--����� ��������� �������: select [dbo].<Name_Function> (null|[@<Paramener_Name>, <Data_Type>])
--����� ��������� �������: select * from [dbo].<Name_Function> (null|[@<Paramener_Name>, <Data_Type>])

--������. ������� ��������� ����� �� �������� ���������

create or alter function [dbo].[Posts_Employee_Summary](@Post_Name [varchar] (max))
returns [decimal] (38,2)
with execute as caller
as
begin
	declare @Sum [decimal] (38,2) = (select sum([dbo].[Post].[Cost_Post] * [dbo].[Combination].[Part_Post]*0.87) from [dbo].[Combination]
	inner join [dbo].[Post] on [Post_ID] = [ID_Post]
	where [dbo].[Post].[Name_Post] = @Post_Name)
	return(@Sum)
end
go
select [dbo].[Posts_Employee_Summary]('��������')

--������. ������� ������ � ������ �� ����������, �� ��������� ���
create or alter function [dbo].[Posts_Information](@FNM_Info [varchar] (max))
returns table
as
	return(select [dbo].[Post].[Name_Post] + ' ' + CONVERT([varchar] (max), [dbo].[Post].[Cost_Post] * [dbo].[Combination].[Part_Post] * 0.87) as "���������� �� ���������",
	[dbo].[Combination].[Part_Post] as "������ �� ���������" from [dbo].[Combination]
	inner join [dbo].[Post] on [Post_ID] = [ID_Post]
	inner join [dbo].[Employee] on [ID_Employee] = [Employee_ID]
	where [First_name] + ' ' + [Name_employee] + ' ' + [Middle_name] = @FNM_Info)
go
select * from [dbo].[Posts_Information]('������ ���� ��������')

--DDL. �������� - ��� �����������, ������� ����������� ��� ����������� �� �������� ������������
--����������� � 9 ���������: ���, �����, ������, ����������, ��������� � �������� ������
--�����������: create or alter trigger [dbo].<Trigger_Name> on <Table_Name>
--for|alfter|istead insert|update|delete
--as
--<Trigger_Body>
--go

create table [dbo].[Employee_History]
(
	[ID_History] [int] not null identity(1,1),
	[Employee_Info] [varchar] (max) not null,
	[Post_Info] [varchar] (max) not null,
	[Date_Of_Create] [datetime] not null,
	constraint [PK_History] primary key clustered
	([ID_History] ASC) on [PRIMARY]
)
go

create or alter trigger [dbo].[History_Update] on [dbo].[Combination]
after insert, update
as
	insert into [dbo].[Employee_History] ([Employee_Info], [Post_Info], [Date_Of_Create])
	values ((select [dbo].[Employee].[First_name] + ' ' + [dbo].[Employee].[Name_employee] + ' ' + [dbo].[Employee].[Middle_name] from [dbo].[Employee]
	where [dbo].[Employee].[ID_Employee] = (select [Employee_ID] from [inserted])),
	(select [dbo].[Post].[Name_Post] + ' ' + CONVERT([varchar] (max), [dbo].[Post].[Cost_Post] * (select [Part_Post] from [inserted]) * 0.87) from [dbo].[Post]
	where [ID_Post] = (select [Post_ID] from [inserted])), GETDATE())
go
insert into [dbo].[Combination] ([Employee_ID], [Post_ID], [Part_Post])
values (2,3,0.7)
select * from [dbo].[Employee_History]