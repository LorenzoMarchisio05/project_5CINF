-- 1) vis modelli con almeno 2 auto
select modello, count(*) as 'Numero Auto'
from AUTO, MODELLI
where
	AUTO.idModello = MODELLI.idModello
group by modello
having count(*) >= 2;


-- 2) i modelli per i quali c’è almeno 1 auto
select modello, count(*) as 'Numero Auto'
from AUTO, MODELLI
where 
	AUTO.idModello = MODELLI.idModello
group by modello
having count(*) >= 1;


-- 3) vis. cilindrata, prezzo, colore e modello dell’auto di cui si conosce la targa
select cilindrata, prezzo, colore, modello
from AUTO, COLORI, MODELLI
where 
	AUTO.idModello = MODELLI.idModello 
	and AUTO.idColore = COLORI.idColore
	and AUTO.targa = 'AB342CH';
-- or 
select cilindrata, prezzo, colore, modello
from AUTO
	inner join MODELLI on AUTO.idModello = MODELLI.idModello
	inner join COLORI on AUTO.idColore = COLORI.idColori 
where 
	targa = 'AB342CH';  


-- 4) vis. tutti i dati delle auto mercedes gialle
select * 
from AUTO
where 
	idModello in (select distinct idModello 
				 from MODELLI 
				 where MODELLI.idMarca = (select distinct idMarca 
										  from MARCHE 
										  where marca = 'fiat'))
	and idColore = (select distinct idColore 
					from COLORI 
					where colore = 'nero');
-- or
select *
from AUTO, MODELLI, MARCHE, COLORI
where 
	MARCHE.marca = 'fiat'
	and COLORE.colore = 'nero'
	and AUTO.IdModello = MODELLI.idModello
	and MODELLI.idMarca = MARCHE.idMarca
	and AUTO.idColore = COLORI.idColore;


-- 5) vis per ogni marca il totale importo escludendo le marche con 1 sola auto
select marca, count(*) as 'Numero Auto', SUM(prezzo) as 'Prezzo Totale'
from AUTO, MODELLI, MARCHE
where 
	AUTO.idModello = MODELLI.idModello 
	and MODELLI.idMarca = MARCHE.idMarca
group by marca
having count(*) > 1;

-- 6) vis targa e modello delle auto di colore rosso che costano meno di 15000
select targa, modello, prezzo
from AUTO, MODELLI
where 
	AUTO.idModello = MODELLI.idModello
	and AUTO.idColore = (select distinct idColore
						 from COLORI
						 WHERE colore = 'rosso')
	and prezzo < 15000;


-- 7) i dati dell’auto più costosa
select top 1 with ties * 
from AUTO
order by prezzo desc;


-- 8) i dati delle auto che costano meno del costo medio
select *
from AUTO
where prezzo < (select AVG(prezzo)
				from AUTO);


-- 9) le auto del modello clio con prezzo superiore a quello di almeno un’auto del modello micra
select *
from AUTO, MODELLI
where AUTO.idModello = MODELLI.idModello
	and MODELLI.idMarca = (select distinct idMarca 
						   from MARCHE
						   where marca = 'renault')
	and prezzo > (select top 1 prezzo
				  from AUTO, MODELLI
				  where AUTO.idModello = MODELLI.idModello
						and MODELLI.idMarca = (select distinct idMarca 
											   from MARCHE
											   where marca = 'fiat')
				  order by prezzo asc);


-- 10) le auto marca renault con prezzo superiore a quello di tutte le auto fiat
select *
from AUTO, MODELLI
where AUTO.idModello = MODELLI.idModello
	and MODELLI.idMarca = (select distinct idMarca 
						   from MARCHE
						   where marca = 'renault')
	and prezzo > (select top 1 prezzo
				  from AUTO, MODELLI
				  where AUTO.idModello = MODELLI.idModello
						and MODELLI.idMarca = (select distinct idMarca 
											   from MARCHE
											   where marca = 'fiat')
				  order by prezzo desc);