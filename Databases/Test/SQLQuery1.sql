(
	select 
		* 
	from 
		Lauerati
)
union
(
	select 
		* 
	from 
		Quadri
)

(
	select 
		* 
	from 
		Lauerati
)
intersect
(
	select 
		* 
	from 
		Quadri
)


(
	(
		select 
			* 
		from 
			Lauerati
	)
	except
	(
		select 
			* 
		from 
			Quadri
	)
)
union
(
	(
		select 
			* 
		from 
			Quadri
	)
	except
	(
		select 
			* 
		from 
			Lauerati
	)
);

select 
	matricola, cognome
from
	Impiegati;

select 
	cognome, filiale
from
	Impiegati;

select 
	*
from
	Impiegati
where 
	stipendio >= 62000;

select 
	matricola, cognome
from
	Impiegati
where
	stipendio >= 62000 and
	filiale = 'milano'

select 
	matricola, cognome
from
	Impiegati
where 
	stipendio >= 62000;

