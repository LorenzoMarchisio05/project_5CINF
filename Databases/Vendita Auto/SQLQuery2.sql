go;
select modello, AVG(prezzo) 
from AUTO, MODELLI
where AUTO.idModello = MODELLI.idModello
group by modello;

go;
select targa, modello, prezzo
from auto, MODELLI
where AUTO.idModello = MODELLI.idModello;

go;
select A1.targa, M1.modello, A1.prezzo - (select AVG(A2.prezzo) 
								from AUTO as A2, MODELLI as M2
								where A2.idModello = M2.idModello
									and M2.idModello = M1.idModello) as 'Scostamento'
from AUTO as A1, MODELLI as M1
where A1.idModello = M1.idModello;

go;
alter view datiAuto
as 
select targa, cilindrata, marca, modello, (prezzo + prezzo*30/100) as 'Prezzo aumentato del 30%'
from AUTO, MODELLI, MARCHE
where AUTO.idModello = MODELLI.idModello
	and MODELLI.idMarca = MARCHE.idMarca;

go;
select * from datiAuto;