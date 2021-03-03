set ansi_padding on
go
set quoted_identifier on 
go
set ansi_nulls on 
go

create database [Andrey]--ñîçäàíèå îáúåêòà ÁÄ
go

use    Andrey
go

create table [dbo].[Users]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_User] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Login] [varchar] (50) not null, 
	[Password] [varchar] (50) not null,
	constraint [PK_Users] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_User] ASC) on [PRIMARY]
)
go


create table [dbo].[type_of_activity]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_Type] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Name_of_Type] [varchar] (50) not null, 
	constraint [PK_type_of_activity] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_Type] ASC) on [PRIMARY]
)
go

create table [dbo].[form_of_control]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_Form] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Name_of_Form] [varchar] (50) not null, 
	constraint [PK_form_of_control] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_Form] ASC) on [PRIMARY]
)
go

create table [dbo].[categoty_of_teacher]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_Category] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Name_of_Category] [varchar] (50) not null, 
	constraint [PK_categoty_of_teacher] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_Category] ASC) on [PRIMARY]
)
go

create table [dbo].[Group]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_group] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Name_of_group] [varchar] (50) not null, 
	[Facultet] [varchar] (50) not null,
	[Kafedra] [varchar] (50) not null,
	constraint [PK_Group] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_group] ASC) on [PRIMARY]
)
go

create table [dbo].[Students]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_student] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Sername] [varchar] (100) not null, 
	[Name] [varchar] (100) not null, 
	[Middlename] [varchar] (100) not null, 
	[Kurs] [varchar] (50) not null,
	[group_ID] [integer] foreign key references [dbo].[Group](ID_group)
	constraint [PK_Students] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_student] ASC) on [PRIMARY]
)
go

create table [dbo].[Teacher]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_teacher] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[SernameT] [varchar] (100) not null, 
	[NameT] [varchar] (100) not null, 
	[MiddlenameT] [varchar] (100) not null, 
	[Kurs] [varchar] (50) not null,
	[Category_ID] [integer] foreign key references [dbo].[categoty_of_teacher](ID_Category)
	constraint [PK_Teacher] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_teacher] ASC) on [PRIMARY]
)
go

create table [dbo].[Study_plan]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_plan] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Subject] [varchar] (50) not null, 
	[Kurs] [varchar] (50) not null, 
	[semestr] [varchar] (50) not null, 
	[hour] [integer] not null, 
	[teacher_ID] [integer] foreign key references [dbo].[Teacher](ID_teacher),
	[Form_ID] [integer] foreign key references [dbo].[form_of_control](ID_Form),
	[Type_ID] [integer] foreign key references [dbo].[type_of_activity](ID_Type)
	constraint [PK_Study_plan] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_plan] ASC) on [PRIMARY]
)
go

create table [dbo].[Study_order]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_order] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[Kafedra] [varchar] (100) not null, 
	[Category_ID] [integer] foreign key references [dbo].[categoty_of_teacher](ID_Category),
	[plan_ID] [integer] foreign key references [dbo].[Study_plan](ID_plan),
	[group_ID] [integer] foreign key references [dbo].[Group](ID_group)
	constraint [PK_Study_order] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_order] ASC) on [PRIMARY]
)
go



create table [dbo].[Ratings]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_rate] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[ratings] [varchar] (100) not null, 
	[student_ID] [integer] foreign key references [dbo].[Students](ID_student),
	[plan_ID] [integer] foreign key references [dbo].[Study_plan](ID_plan)
	constraint [PK_Ratings] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_rate] ASC) on [PRIMARY]
)
go

create table [dbo].[Diplom]--Ñîçäàíèå òàáëèöû "Ïîëüçîâàòåëè"
(
	[ID_diplom] [integer] not null identity (1,1),--Öåëî÷èñëåííîå, îáÿçàòåëüíîå äëÿ çàïîëíåíèÿ, ïîëå ñ ñâîéñòâîì àâòîèíêðåìåíòà ñî ñòàðòîâûì çíà÷åíèå - 1 è ñ øàãîì óâåëè÷åíèÿ - 1
	[number_diplom] [varchar] (100) not null, 
	[student_ID] [integer] foreign key references [dbo].[Students](ID_student),
	[teacher_ID] [integer] foreign key references [dbo].[Teacher](ID_teacher)
	constraint [PK_Diplom] primary key clustered --Óêàçàíèå ïåðâè÷íîãî êëþ÷à äëÿ òàáëèöû
	([ID_diplom] ASC) on [PRIMARY]
)
go
