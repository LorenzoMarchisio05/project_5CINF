-- 1. produrre un elenco delle prestazioni ordinato in modo decrescente secondo il numero di ore erogate per ciascuna prestazione .
select Materia, sum(NOre) as 'Numero ore'
from Prestazioni
	join Materie on (Prestazioni.IdMateria = Materie.IdMateria)
where Erogata = 1
group by Materia
order by [Numero ore] desc;



go;
-- 2. visualizzare tutti i soci che fanno parte della segreteria e che offrono anche altri tipi di prestazione;
select IdSocio, Cognome, Nome 
from soci 
where IdTipo = (select IdTipo from TipiSoci where Tipo = 'segreteria') 
	and exists (select IdInsegna from Disponibilita where Disponibilita.IdSocio = IdSocio);

go;
-- 3. data una richiesta di prestazione, visualizzare l'elenco di tutti i soci in grado di erogare 
-- quella prestazione, visualizzandone il nome, cognome, indirizzo, email e numero di telefono ;
select (Soci.Cognome + ' '  + Soci.Nome) as 'nominativo', Soci.Email
from Soci
	join Disponibilita on (Soci.IdSocio = Disponibilita.IdSocio)
where IdMateria in ( 
	select IdMateria 
	from Materie 
	where Materia like 'informatica%'
);

go;
-- 4. produrre l' elenco dei soci (con cognome, nome, email e telefono) che hanno un “debito”
-- nella BdT (coloro che hanno usufruito di ore di prestazioni in numero superiore a quelle erogate
create view SociInDebito as
select Soci.idSocio, Soci.Cognome, Soci.Nome, Soci.Email
from Soci
where Soci.OreRicevute > Soci.OreErogate;

go;

select * from SociInDebito;

select P1.idOfferente, ( ISNULL( (select sum(NOre) from Prestazioni as P2 where P2.IdOfferente = P1.IdOfferente), 0) 
- ISNULL( (select sum(NOre) from Prestazioni as P3 where P3.IdRicevente = P1.IdOfferente), 0)) as [differenzaPrestazione]
from Prestazioni as P1
group by P1.IdOfferente; 