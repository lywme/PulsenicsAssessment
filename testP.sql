create database testP;

create table users(
	userId bigint primary key identity(1,1),
	userName varchar(20),
	email varchar(30), 
	phone varchar(30)
);

create table files(
	fileId bigint primary key identity(1,1),
	fileName varchar(40),
	fileSize real
);

create table fileOwner(
	fileId bigint,
	userId bigint,
	constraint PK_owner primary key (fileId,userId),
	constraint FK_users foreign key (userId) references users (userId) on delete cascade,
	constraint FK_files foreign key (fileId) references files (fileId) on delete cascade,
);

use testP;
select * from users;