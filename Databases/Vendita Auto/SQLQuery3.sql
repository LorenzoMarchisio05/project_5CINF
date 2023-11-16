drop trigger Trigger_InseriteTroppeAutoConLoStessoModello;
drop trigger Trigger_Prezzi;
drop trigger Trigger_InserimentoAutoModelloColoreCilindrata;
drop trigger Trigger_InserimentoAutoTarga;
go;

create trigger Trigger_InseriteTroppeAutoConLoStessoModello
on [Auto]
for insert, update
as 
begin
	declare @idModello int;
	declare @countAutoModello int;

	select @idModello = idModello from inserted;
	select @countAutoModello = COUNT(*) 
	from [AUTO]
	where idModello = @idModello;

	if(@countAutoModello >= 3) 
	begin
		print 'Too many cars with the same model';
		rollback transaction;
	end;
end

go;

create trigger Trigger_Prezzi
on [Auto]
for update
as
begin
	declare @targa varchar(7);
	declare @vecchioPrezzo float;
	declare @nuovoPrezzo float;

	select @vecchioPrezzo = prezzo from deleted;
	select @targa = targa, @nuovoPrezzo = prezzo from inserted;

	if(@vecchioPrezzo <> @nuovoPrezzo)
	begin
		if(not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'storicoPrezzi'))
		begin
			create table storicoPrezzi (
				idStorico int primary key identity(1,1),
				targa varchar(7) not null,
				vecchioPrezzo float not null,
				nuovoPrezzo float not null,
				dataOraAggiornamento datetime not null constraint dfl_dataOraAggiornamento default getdate(),
			);
		end;

		insert into storicoPrezzi
		(targa, vecchioPrezzo, nuovoPrezzo)
		values
		(@targa, @vecchioPrezzo, @nuovoPrezzo);
	end;	
end;
go;

-- Bloccare l’inserimento di un’auto con stesso modello, colore e cilindrata
create trigger Trigger_InserimentoAutoModelloColoreCilindrata 
on [AUTO]
instead of insert, update
as
begin
	declare @idModello int;
	declare @idColore int;
	declare @cilindrata int;

	select @idModello = idModello, @idColore = idColore, @cilindrata = cilindrata from inserted;

	if(exists(select * from [AUTO]
				where idModello = @idModello
				and idColore = @idColore 
				and cilindrata = @cilindrata))
	begin
		print 'cè gia un auto con lo stesso modello, colore e cilindrata'
		rollback transaction;
	end;
	else
	begin
		insert into [AUTO] (targa, cilindrata, prezzo, idModello, idColore)
		select targa, cilindrata, prezzo, idModello, idColore from inserted;
	end;
end;
go;
-- Consentire l’inserimento di un’auto con targa che ha le prime 2 lettere da CB in avanti
create trigger Trigger_InserimentoAutoTarga
on [AUTO]
for insert, update
as
begin
	declare @targa varchar(7);

	select @targa = targa from inserted;
	

	if(SUBSTRING(@targa, 1, 2) < 'CB') 
	begin
		print 'targa non valida';
		rollback transaction;
	end;
end;

go;
-- Visualizzare tutti i dati delle auto che hanno il prezzo superiore a tutte
select * 
from auto 
where prezzo >= ALL(select prezzo from AUTO);

-- Visualizzare le marche a cui appartengono le auto in ordine di marca
select distinct marca
from auto, modelli, marche
where auto.idModello = modelli.idModello
	and modelli.idMarca = marche.idMarca
order by marca asc;


-- Contare a quante marche diverse appartengono le auto
select count( distinct marca) as 'marche diverse'
from auto, modelli, marche
where auto.idModello = modelli.idModello
	and modelli.idMarca = marche.idMarca;

insert into AUTO
(targa, cilindrata, prezzo, idModello, idColore)
values
('AA123DV', 1000, 2200, 5, 2);


select * from auto
where cilindrata = 1000
and idModello = 5
and idColore = 2;