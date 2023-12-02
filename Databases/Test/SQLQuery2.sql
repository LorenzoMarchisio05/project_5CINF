-- abbonati comuni a 2 pubblicazioni di cui si sa il titolo
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo1
)
intersect
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo2
)

-- abbonati alla rivista xx e non alla rivista yy
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo1
)
except
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo2
)

-- elenco degli abbonati a 2 riviste xx e yy
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo1
)
union
(
	select 
		abbonati.codiceAbbonato, nome, cognome 
	from 
		abbonati
	join 
		abbonamenti
	on
		(abbonati.codiceAbbonato = abbonamenti.codiceAbbonato)
	join 
		pubblicazioni 
	on 
		(abbonamenti.codicePubblicazione = pubblicazioni.codicePubblicazione)
	where 
		titolo = @titolo2
)

-- visualizzare per ogni pubblicazione il numero di abbonati ed il totale importo degli abbonamenti trimestrali

select 
	pubblicazioni.CodicePubblicazione, 
	titolo, 
	count(abbonamenti.codiceAbbonati) as 'Numero abbonati', 
	sum(costroTrimestrale) as 'Costo trimestrale'
from 
	pubblicazioni
join
	abbonamenti
on
	(pubblicazioni.codicePubblicazione = abbonamenti.codicePubblicazione)
where 
	tipoAbbonamento = 'trimestrale'
group by 
	pubblicazione.CodicePubblicazione, titolo;

-- visualizzare i giornali con almeno 100 abbonamenti annuali
select 
	pubblicazioni.codicePubblicazione, titolo
from
	pubblicazioni
join
	abbonamenti
on 
	(pubblicazoni.codicePubblicazione = abbonamenti.codicePubblicazione)
where 
	GR = 'G' and
	tipoAbbonamento = 'annuale'
group by
	pubblicazioni.codicePubblicazione, titolo
having 
	count(*) >= 100;