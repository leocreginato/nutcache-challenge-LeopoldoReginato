create database DBNutcache
use DBNutcache

create table Gender(
Id int primary key identity,
Name varchar(50) NOT NULL
)

create table Team(
Id int primary key identity,
Name varchar(50) NOT NULL
)

create table Employee(
Id int primary key identity,
Name varchar(50) NOT NULL,
BirthDate datetime NOT NULL,
IdGender int references Gender(Id) NOT NULL,
Email varchar(50) NOT NULL,
Cpf varchar(11) NOT NULL,
StartDate datetime NOT NULL,
IdTeam int references Team(Id),
)

insert into Gender(Name) values
('Female'),
('Male'),
('Other')

insert into Team(Name) values
('Backend'),
('Frontend'),
('Mobile')


--Scaffold-DbContext "Server=DESKTOP-LN0G1NF; DataBase=DBNutcache; Password=senha; User ID=sa; trusted_connection=true; Trust Server Certificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models