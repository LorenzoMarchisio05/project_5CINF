drop procedure MemorizzaPrestazioniAnnoPassatoStorico;

go;

create procedure MemorizzaPrestazioniAnnoPassatoStorico
	@anno int
as
	
	if not exists (
			select 1 
			from INFORMATION_SCHEMA.TABLES 
			where TABLE_NAME = 'StoricoPrestazioniPassate'
	) 
	begin
		create table StoricoPrestazioniPassate(
			id int primary key identity(1, 1),

			idPrestazione int not null,
			DataOraInizio datetime not null,
			NOre int not null,
			Descrizione varchar(200) null,
			idOfferente int not null,
			idRicevente int not null,
			idTipo int not null,
			idMateria int not null,
			erogata bit not null,
		);
	end

	insert into StoricoPrestazioniPassate
	(idPrestazione, DataOraInizio, Nore, Descrizione, idOfferente, idRicevente, IdTipo, idMateria, erogata)
	select * 
	from Prestazioni
	where YEAR(DataOraInizio) = @anno;

	delete from Prestazioni
	where YEAR(DataOraInizio) = @anno;
return 0

go;

insert into Prestazioni
(DataOraInizio, NOre, IdOfferente, IdRicevente, IdTipo, IdMateria)
values
('20160713 10:00:00 AM', 2, 2, 3, 1, 1),
('20160713 11:00:00 AM', 2, 2, 4, 1, 2),
('20160713 9:00:00 AM', 2, 2, 3, 1, 3),
('20170713 6:00:00 AM', 2, 3, 2, 1, 5),
('20170813 10:00:00 AM', 5, 4, 2, 1, 1);

select * from Prestazioni;

select * from StoricoPrestazioniPassate;

drop table StoricoPrestazioniPassate;

exec MemorizzaPrestazioniAnnoPassatoStorico 2016;

go;

drop procedure MostraPrestazioniOreSocioAnno;

go;

-- visualizzare il totale di ore e numero di prestazioni effettuate da un socio in un anno;

create procedure MostraPrestazioniOreSocioAnno 
	@idSocio int,
	@anno int
as
	select sum(NOre) as 'numero ore', count(*) as 'numero prestazioni'
	from Prestazioni
	where IdOfferente = @idSocio 
		and YEAR(DataOraInizio) = @anno
		and Erogata = 1;
return 0;

go;


select * from Prestazioni where Erogata = 1;

exec MostraPrestazioniOreSocioAnno 2, 2016;

go;

-- visualizza soci che non hanno fatto prestazioni nel'anno corrente

select * from Prestazioni;

declare @anno int = 2016;

select *
from Soci
where exists (
	select 1 
	from Prestazioni 
	where YEAR(DataOraInizio) = @anno 
		and IdOfferente = IdSocio
);

go;

-- id socio cognome, nome e numero di prestazione fatta
select idSocio, Cognome, Nome, idPrestazione
from Soci
	left join Prestazioni on IdOfferente = IdSocio
order by IdSocio;

-- per ogni materia cognome e nome socio disponibile + materie senza disponibilita
select * from Materie;

insert into Materie (Materia) values ('materia senza disponibilita');

select Materia, Cognome, Nome
from Materie
	left join Disponibilita on Materie.IdMateria = Disponibilita.IdMateria
	left join Soci on Disponibilita.IdSocio = Soci.IdSocio;
