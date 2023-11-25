ALTER TABLE Vendite DROP CONSTRAINT fk_idCliente;
ALTER TABLE Vendite DROP CONSTRAINT fk_idArticolo;
ALTER TABLE Articoli DROP CONSTRAINT fk_idGenere;

ALTER TABLE Articoli DROP CONSTRAINT chk_giacenza;
ALTER TABLE Articoli DROP CONSTRAINT chk_giacenzaMinima

ALTER TABLE Articoli DROP CONSTRAINT pk_idArticolo;
ALTER TABLE Clienti DROP CONSTRAINT pk_idCliente;

if exists (
	select 1 from INFORMATION_SCHEMA.TABLES
	where TABLE_NAME = 'StoricoPrezzi'
) 
begin
	ALTER TABLE StoricoPrezzi DROP CONSTRAINT pk_idCliente;
	DROP TABLE StoricoPrezzi;
end

DROP TABLE Articoli;
DROP TABLE Clienti;
DROP TABLE Vendite;
DROP TABLE Generi;

DROP VIEW SottoScorta;

DROP TRIGGER trigger_aggiornaGiacenza;
DROP TRIGGER trigger_aggiornaPrezzo;
go;

--definizioni

create table Generi (
	idGenere int primary key identity(1, 1),
	genere varchar(100) not null,
);

create table Articoli (
	idArticolo int not null identity(1, 1),
	descrizione text null,
	giacenza int null default 0,
	giacenzaMinima int not null,
	prezzo money not null,
	idGenere int not null,

	constraint chk_giacenza check ( giacenza > 0),
	constraint chk_giacenzaMinima check ( giacenzaMinima > 0),
	constraint pk_idArticolo primary key (idArticolo),
	constraint fk_idGenere foreign key (idGenere) 
		references Generi(idGenere),
);

create table Clienti (
	idCliente int not null identity(1, 1),
	ragioneSociale varchar(100) not null,
	partitaIva varchar(11) not null,
	telefono varchar(15) not null,
	email varchar(100) not null,

	constraint pk_idCliente primary key (idCliente),
);

create table Vendite (
	idVendita int not null identity(1, 1),
	quantita int not null,
	dataVendita date null default CONVERT(date, GETDATE()),
	pagato bit null default 0,
	idCliente int not null,
	idArticolo int not null,

	constraint fk_idCliente foreign key (idCliente)
		references Clienti(idCliente),
	constraint fk_idArticolo foreign key (idArticolo)
		references Articoli(idArticolo)
);

go;
-- dati

INSERT INTO Generi 
(genere)
VALUES 
('Fiction'),
('Non-Fiction'),
('Mystery'),
('Science Fiction'),
('Romance');

INSERT INTO Articoli 
(descrizione, giacenza, giacenzaMinima, prezzo, idGenere)
VALUES 
('Book 1', 20, 10, 24.99, 1),
('Book 2', 15, 8, 29.99, 2),
('Mystery Novel', 12, 6, 19.99, 3),
('Sci-Fi Book', 18, 9, 27.99, 4),
('Romance Novel', 10, 5, 22.99, 5);

INSERT INTO Clienti 
(ragioneSociale, partitaIva, telefono, email)
VALUES 
('ABC Bookstore', '12345678901', '123-456-7890', 'abc@store.com'),
('XYZ Bookshop', '98765432109', '987-654-3210', 'xyz@bookshop.com'),
('Best Reader', '11122334455', '555-555-5555', 'best@reader.com');

INSERT INTO Vendite 
(quantita, dataVendita, pagato, idCliente, idArticolo)
VALUES 
(5, '2023-11-25', 1, 1, 1),
(8, '2021-11-26', 0, 2, 2),
(3, '2022-11-27', 1, 3, 3),
(6, '2023-11-28', 0, 1, 4),
(2, '2023-11-29', 1, 2, 5);


go;
-- view
create view SottoScorta 
as
	select idArticolo, descrizione, genere
	from Articoli
		join Generi on (Generi.idGenere = Articoli.idGenere)
	where giacenza < giacenzaMinima;

go;
-- trigger 1 ( Aggiorna giacenza )
create trigger trigger_aggiornaGiacenza
on vendite
after insert 
as
begin
	declare @quantitaRichiesta int;
	declare @quantitaDisponibile int;
	declare @quantitaMinima int;
	declare @idArticolo int;

	select 
		@idArticolo = idArticolo,
		@quantitaRichiesta = quantita
	from inserted;

	select 
		@quantitaMinima = giacenzaMinima,
		@quantitaDisponibile = giacenza
	from Articoli
	where idArticolo = @idArticolo;

	if (
		@quantitaDisponibile - @quantitaRichiesta < @quantitaMinima
	)
	begin
		print 'non cè abbastanza prodotto';
		rollback transaction;
	end
	
	update Articoli 
		set giacenza = giacenza - @quantitaRichiesta
	where idArticolo = @idArticolo;
end;

go;
-- trigger 1 ( Aggiorna giacenza )
create trigger trigger_aggiornaPrezzo
on Articoli
for update
as
begin
	declare @idArticolo int;
	declare @prezzoVecchio money;
	declare @prezzoNuovo money;
	
	select 
		@idArticolo = idArticolo,
		@prezzoNuovo = prezzo
	from inserted;

	select 
		@prezzoVecchio = prezzo
	from deleted;

	if not exists (
		select 1 from INFORMATION_SCHEMA.TABLES
		where TABLE_NAME = 'StoricoPrezzi'
	)
	begin
		create table StoricoPrezzi
		(
			idStorico int not null identity(1, 1),
			idArticolo int not null,
			descrizione text not null,
			prezzoPrima money not null,
			prezzoDopo money not null,
			dataOraModifica date null default getdate(),

			constraint pk_idStorico primary key (idStorico),
		);
	end;

	if (@prezzoNuovo <> @prezzoVecchio) 
	begin
		insert into StoricoPrezzi 
		(idArticolo, prezzoPrima, prezzoDopo)
		values
		(@idArticolo, @prezzoVecchio, @prezzoNuovo);

		declare @id int;
		select @id = SCOPE_IDENTITY();

		update StoricoPrezzi
			set descrizione = (
				select descrizione from inserted
			)
		where idStorico = @id;
	end;

end;

go;
-- query

-- 1.
select 
	idArticolo, descrizione
from 
	Articoli
where 
	prezzo >= ALL(select prezzo from Articoli);

-- 2.
select 
	idArticolo, descrizione
from 
	Articoli
where  
	idArticolo not in (
		select 
			distinct idArticolo 
		from 
			Vendite 
		where 
			YEAR(dataVendita) = YEAR(GETDATE())
);

-- 3.
select 
	Clienti.idCliente, ragioneSociale, sum(prezzo * quantita)
from 
	Clienti
join 
	Vendite on (Vendite.idCliente = Clienti.idCliente)
join
	Articoli on (Articoli.idArticolo = Vendite.idArticolo)
where 
	pagato = 0
group by 
	Clienti.idCliente, ragioneSociale;

-- 4.
declare @descrizione varchar(255) = 'Book 1';

select
	sum(quantita), count(distinct idCliente)
from 
	Vendite
join
	Articoli on (Articoli.idArticolo = Vendite.idArticolo)
where 
	descrizione like @descrizione;

-- 5.
if exists (
	select 1 from INFORMATION_SCHEMA.VIEWS
	where TABLE_NAME = 'SottoScorta'
)
begin
	select * from SottoScorta;
end
else
begin
	print 'NON-TROVATA';
end