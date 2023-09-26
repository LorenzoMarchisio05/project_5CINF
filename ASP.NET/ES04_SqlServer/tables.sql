create table Materie (
	IdMateria int identity(1, 1) primary key,
	Materia varchar(50) not null,
);

create table Alunni (
	IdAlunno int identity(1,1) primary key,
	Nome varchar(75) not null,
	Cognome varchar(75) not null,
);

create table Voti (
	IdVoto int identity(1,1) primary key,
	IdAlunno int not null,
	IdMateria int not null,

	Voto float not null,
	DataVoto date constraint dfl_data default getdate(),

	constraint fk_id_alunno foreign key (IdAlunno) references Alunni(IdAlunno),
	constraint fk_id_materia foreign key (IDMateria) references Materie(IdMateria),
);

insert into Materie 
	(Materia) 
values 
	('Informatica'),
	('Sistemi'),
	('Tecnologie'),
	('Italiano'),
	('Storia'),
	('Matematica'),
	('Inglese');

insert into Alunni 
	(Nome, Cognome)
values
	('nome1', 'cognome1'),
	('nome2', 'cognome2'),
	('nome3', 'cognome3'),
	('nome4', 'cognome4'),
	('nome5', 'cognome5'),
	('nome6', 'cognome6'),
	('nome7', 'cognome7'),
	('nome8', 'cognome8');


insert into Voti 
	(IdAlunno, IdMateria, Voto) 
values
	(1, 1, 8.5),
	(4, 1, 7.5),
	(2, 5, 7),
	(1, 4, 6),
	(3, 3, 5.5),
	(2, 6, 9),
	(5, 1, 10);

