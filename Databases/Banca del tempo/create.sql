--TIPISOCIO(IdTipo, Tipo)
create table TipiSoci (
	IdTipo int primary key,
	Tipo varchar(50) not null,
);

--SOCI (IdSocio, Cognome, Nome, Email, Pwd, OreErogate, OreRicevute, IdTipo, IdResponsabile?)
create table Soci (
	IdSocio int primary key identity(1,1),
	Cognome varchar(75) not null,
	Nome varchar(75) not null,
	Email varchar(100) not null,
	Pwd varchar(75) not null,
	OreErogate int constraint dfl_OreErogate default 0,
	OreRicevute int constraint dfl_OreRicevute default 0,
	IdTipo int not null,
	IdResponsabile int null,
	foreign key (IdTipo) references TipiSoci(IdTipo),
);

--TIPIPRESTAZIONI (IdTipo, Tipo)
create table TipiPrestazioni(
	idTipo int primary key identity(1, 1),
	Tipo varchar(75) not null,
);

--MATERIE (IdMateria, Nome)
create table Materie(
	IdMateria int primary key identity(1,1),
	Materia varchar(100) not null,
);

--DISPONIBILITA (IdInsegna, IdSocio, IdMateria)
create table Disponibilita (
	IdInsegna int primary key identity(1, 1),
	IdSocio int not null,
	IdMateria int not null,

	foreign key (IdSocio) references Soci(IdSocio),
	foreign key (IdMateria) references Materie(IdMateria),
);

--PRESTAZIONI (IdPrestazione, DataOraInizio, NOre, Descrizione, IdOfferente, IdRicevente, IdTipo, IdMateria?)
create table Prestazioni (
	IdPrestazione int primary key identity(1, 1),
	DataOraInizio DateTime not null,
	NOre int not null,
	Descrizione varchar(150),
	IdOfferente int not null, 
	IdRicevente int not null,
	IdTipo int not null,
	IdMateria int not null,
	Erogata bit constraint dfl_Erogata default 0,

	constraint chk_NOre check (NOre > 0),
	constraint chk_IdOfferenteDiversoIdRicevente check (IdOfferente <> idRicevente),
	foreign key (IdOfferente) references Soci(IdSocio),
	foreign key (IdRicevente) references Soci(IdSocio),
	foreign key (IdTipo) references TipiPrestazioni(IdTipo),
	foreign key (IdMateria) references Materie(IdMateria),
);

go; -- DELETE TRIGGER 

drop trigger Trigger_ControlloMateriaInseritaPrestazione;
drop trigger Trigger_AggiornaSocioDopoInserimentoPrestazione;

go; -- TRIGGERS

create trigger Trigger_ControlloMateriaInseritaPrestazione
	on Prestazioni 
	for insert
as
begin
	declare @idMateria int;
	declare @idOfferente int;

	select @idMateria = IdMateria, @idOfferente = IdOfferente from inserted;

	if(@idOfferente not in (select IdSocio 
		from Disponibilita
		where IdMateria = @idMateria)) 
	begin
		print ('inserimento fallito, il socio richiesto non da disponibilità per la materia richiesta');
		rollback transaction;
	end;
end;
go; 

create trigger Trigger_AggiornaSocioDopoInserimentoPrestazione
	on Prestazioni
	after insert
as
begin
	declare @ore int;
	declare @idErogatore int;
	declare @idRicevente int;
	declare @erogata bit;

	select @ore = NOre, @idErogatore = IdOfferente, @idRicevente = IdRicevente, @erogata = Erogata 
	from inserted;

	if(@erogata = 1) 
	begin
		update Soci
		set OreErogate = OreErogate + @ore
		where IdSocio = @idErogatore;

		update Soci
		set OreRicevute = OreRicevute + @ore
		where IdSocio = @idRicevente;
	end;
end;



go; -- INSERT 

insert into TipiSoci 
(IdTipo, Tipo)
values 
(1, 'Amministratore'),
(2, 'Utente'),
(3, 'Segreteria');

select * from TipiSoci;

insert into Soci
(Cognome, Nome, Email, Pwd, IdTipo, IdResponsabile)
values 
('Admin', 'Nome', 'admin@admin.com', 'admin', 1, null),
('Cognome', 'Nome', 'cognome.nome@email.com', 'password', 2, 1),
('Cognome1', 'Nome1', 'cognome1.nome1@email.com', 'password1234', 2, NULL);

select * from Soci;

insert into TipiPrestazioni
(Tipo)
values
('Presenza'),
('Distanza');

select * from TipiPrestazioni;

insert into Materie
(Materia)
values
('Italiano'),
('Storia'),
('Matematica'),
('Informatica (biennio)'),
('Informatica (triennio)'),
('Sistemi e reti'),
('TPSI'),
('Inglese');

select * from Materie;

insert into Disponibilita
(IdSocio, IdMateria)
values
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(3, 7),
(3, 8);

select * from Disponibilita;

insert into Prestazioni
(DataOraInizio, NOre, IdOfferente, IdRicevente, IdTipo, IdMateria)
values
('20150713 10:00:00 AM', 2, 2, 3, 1, 1)
select * from Prestazioni;