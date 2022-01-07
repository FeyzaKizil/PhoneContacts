create database PhoneContacts
go 
use PhoneContacts
go

create table myUser
(
UserID uniqueidentifier primary key,
Username nvarchar(20) unique,
Password nvarchar(20) not null
)

insert into myUser (UserID, Username, Password) values (newid(), 'Demo', 'Demo')

go
create table Contacts
(
ID uniqueidentifier primary key,
Name nvarchar(30) not null,
Lastname nvarchar(30) not null,
PhoneNumber1 nvarchar(12),
PhoneNumber2 nvarchar(12),
PhoneNumber3 nvarchar(12),
EmailAddress nvarchar(30),
WebAddress nvarchar(30),
Address nvarchar(100),
Info nvarchar(100)
)

go

create proc pNewRecord
(
@ID uniqueidentifier,
@Name nvarchar(30),
@Lastname nvarchar(30),
@PhoneNumber1 nvarchar(12),
@PhoneNumber2 nvarchar(12),
@PhoneNumber3 nvarchar(12),
@EmailAddress nvarchar(30),
@WebAddress nvarchar(30),
@Address nvarchar(100),
@Info nvarchar(100)
)
as
begin
insert into Contacts(ID, Name, Lastname, PhoneNumber1, PhoneNumber2, PhoneNumber3, EmailAddress, WebAddress, Address, Info)
values (@ID, @Name, @Lastname, @PhoneNumber1, @PhoneNumber2, @PhoneNumber3, @EmailAddress, @WebAddress, @Address, @Info)
end

go

create proc pEditRecord
(
@ID uniqueidentifier,
@Name nvarchar(30),
@Lastname nvarchar(30),
@PhoneNumber1 nvarchar(12),
@PhoneNumber2 nvarchar(12),
@PhoneNumber3 nvarchar(12),
@EmailAddress nvarchar(30),
@WebAddress nvarchar(30),
@Address nvarchar(100),
@Info nvarchar(100)
)
as
begin
update Contacts
set
Name = @Name, 
Lastname =  @Lastname, 
PhoneNumber1 = @PhoneNumber1, 
PhoneNumber2 = @PhoneNumber2, 
PhoneNumber3 = @PhoneNumber3, 
EmailAddress = @EmailAddress, 
WebAddress =  @WebAddress, 
Address = @Address, 
Info = @Info
where
ID = @ID
end

go

create proc pDeleteRecord
(
@ID uniqueidentifier
)
as
begin
delete Contacts
where
ID = @ID
end

go

create proc pShowContacts
as
begin
select * from Contacts
end

go

create proc pShowContactID
(
@ID uniqueidentifier
)
as
begin
select * from Contacts
where ID = @ID
end